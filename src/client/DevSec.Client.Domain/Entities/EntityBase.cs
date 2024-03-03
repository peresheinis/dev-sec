namespace DevSec.Client.Core.Entities;

public class EntityBase { 

}

public class EntityBase<T> : EntityBase
    where T : IEquatable<T>
{
    public T Id { get; init; } = default!;
}