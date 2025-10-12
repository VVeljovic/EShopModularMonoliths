namespace Catalog.Features.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id) : IRequest<Result<DeleteProductResponse>>;
