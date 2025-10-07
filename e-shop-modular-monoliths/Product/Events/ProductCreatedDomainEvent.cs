using Product.Models;
using Shared.DDD;

namespace Product.Events;

public sealed record ProductCreatedDomainEvent(Product product) : DomainEvent;
