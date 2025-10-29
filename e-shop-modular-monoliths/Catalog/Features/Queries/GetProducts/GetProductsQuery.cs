namespace Catalog.Features.GetProducts;

public sealed record GetProductsQuery(int PageNumber, int PageSize) : IRequest<Result<GetProductsQueryResponse>>;