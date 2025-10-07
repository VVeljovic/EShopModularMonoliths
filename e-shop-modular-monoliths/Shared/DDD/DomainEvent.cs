using MediatR;

namespace Shared.DDD;

public interface IDomainEvent : INotification
{
    public Guid EventId => Guid.NewGuid();

    public DateTime CreatedAt => DateTime.Now;

    public string EventType  => GetType().AssemblyQualifiedName!;
}
