namespace Catalog.Features.GetProductsByCategory;

public sealed record GetProductsByCategoryQuery(string Category) : IRequest<Result<GetProductsByCategoryQueryResponse>>;
