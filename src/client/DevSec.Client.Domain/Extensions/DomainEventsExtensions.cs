using MediatR;
using DevSec.Client.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevSec.Client.Domain.Extensions;

public static class DomainEventsExtensions
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<EntityBase>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        var tasks = domainEvents
            .Select((domainEvent) => mediator.Publish(domainEvent));

        await Task.WhenAll(tasks);
    }
}
