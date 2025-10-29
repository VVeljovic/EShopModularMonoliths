namespace Catalog.Features.CreateProduct;

public sealed record CreateProductCommand(ProductDto Product) : IRequest<Result<CreateProductResponse>>;