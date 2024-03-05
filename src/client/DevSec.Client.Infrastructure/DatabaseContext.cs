using DevSec.Client.Core.Entities;
using DevSec.Client.Domain.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevSec.Client.Infrastructure;

public class DatabaseContext : DbContext
{
    private readonly IMediator _mediator;

    public DatabaseContext(
        IMediator mediator,
        DbContextOptions<DatabaseContext> optionsBuilder) : base(optionsBuilder)
    {
        _mediator = mediator;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        // Dispatch Domain Events collection.
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB. This makes
        // a single transaction including side effects from the domain event
        // handlers that are using the same DbContext with Scope lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB. This makes
        // multiple transactions. You will need to handle eventual consistency and
        // compensatory actions in case of failures.
        await _mediator.DispatchDomainEventsAsync(this);

        // After this line runs, all the changes (from the Command Handler and Domain
        // event handlers) performed through the DbContext will be committed
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>().OwnsOne(e => e.Location);
        modelBuilder.Entity<Device>().OwnsOne(e => e.Color);
    }

    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceGroup> Groups { get; set; }
    public DbSet<VideoSource> VideoSources { get; set; }
    public DbSet<SoundSource> SoundSources { get; set; }
    public DbSet<DeviceVideo> DeviceVideos { get; set; }
    public DbSet<DeviceSound> DeviceSounds { get; set; }
    public DbSet<VideoConfiguration> VideoConfigurations { get; set; }
    public DbSet<DeviceConfiguration> DeviceConfigurations { get; set; }
}
