namespace Catalog.Features.GetProducts;

public sealed record GetProductsQueryResponse(List<ProductDto> Products, int TotalCount);
