namespace Catalog.Features.GetProducts;

public sealed class GetProductsQueryHandler(CatalogDbContext catalogDbContext) : IRequestHandler<GetProductsQuery, Result<GetProductsQueryResponse>>
{
    public async Task<Result<GetProductsQueryResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var totalCount = catalogDbContext.Products.Count();

        var products = await catalogDbContext.Products
            .AsNoTracking()
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
        
        var productDtos = products.Adapt<List<ProductDto>>();

       return Result<GetProductsQueryResponse>.Ok(new GetProductsQueryResponse(Products: productDtos, TotalCount: totalCount));
    }
}
