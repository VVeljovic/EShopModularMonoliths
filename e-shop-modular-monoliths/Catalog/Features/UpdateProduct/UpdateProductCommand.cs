namespace Catalog.Features.UpdateProduct;

public sealed record UpdateProductCommand(ProductDto Product) : IRequest<Result<UpdateProductResponse>>;
