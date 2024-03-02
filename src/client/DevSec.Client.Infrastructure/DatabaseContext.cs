using DevSec.Client.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevSec.Client.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> optionsBuilder) : base(optionsBuilder)
    {
        
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
