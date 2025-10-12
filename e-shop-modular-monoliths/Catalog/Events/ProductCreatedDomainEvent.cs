namespace Basket.Events;

public sealed record ProductCreatedDomainEvent(Product Product) : IDomainEvent;
