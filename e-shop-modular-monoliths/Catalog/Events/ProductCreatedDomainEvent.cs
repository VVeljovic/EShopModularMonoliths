namespace Basket.Events;

public sealed record ProductCreatedDomainEvent(Product product) : IDomainEvent;
