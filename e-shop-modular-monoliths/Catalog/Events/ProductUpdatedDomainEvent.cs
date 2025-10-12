namespace Basket.Events;

public sealed record ProductUpdatedDomainEvent(Product Product) : IDomainEvent;
