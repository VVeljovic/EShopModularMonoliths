namespace Basket.Events;

public sealed record ProductUpdatedDomainEvent(Product product) : IDomainEvent;
