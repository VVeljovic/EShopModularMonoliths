namespace Catalog.Features.GetProductsByCategory;

public sealed class GetProductsByCategoryQueryHandler(CatalogDbContext catalogDbContext) : IRequestHandler<GetProductsByCategoryQuery, Result<GetProductsByCategoryQueryResponse>>
{
    public async Task<Result<GetProductsByCategoryQueryResponse>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await catalogDbContext.Products
            .AsNoTracking()
            .Where(p => p.Categories.Contains(request.Category))
            .ToListAsync(cancellationToken);

        var productsDtos = products.Adapt<List<ProductDto>>();

        return Result<GetProductsByCategoryQueryResponse>.Ok(new GetProductsByCategoryQueryResponse(productsDtos));
    }
}
