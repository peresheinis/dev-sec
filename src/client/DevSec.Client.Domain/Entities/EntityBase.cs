using MediatR;

namespace DevSec.Client.Core.Entities;

public abstract class EntityBase
{
    private readonly List<INotification> _domainEvents = new List<INotification>();
    
    public EntityBase()
    {
    }

    /// <summary>
    /// Доменные события
    /// </summary>
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents;

    /// <summary>
    /// Добавить доменное событие
    /// </summary>
    /// <param name="notification"></param>
    public void AddDomainEvent(INotification notification) =>
        _domainEvents.Add(notification);

    /// <summary>
    /// Удалить доменное событие
    /// </summary>
    /// <param name="notification"></param>
    public void RemoveDomainEvent(INotification notification) => 
        _domainEvents.Remove(notification);

    /// <summary>
    /// Очистить список доменных событий
    /// </summary>
    public void ClearDomainEvents() =>
        _domainEvents.Clear();
}

public abstract class EntityBase<T> : EntityBase
    where T : IEquatable<T>
{
    public T Id { get; init; } = default!;
}