namespace Catalog.Features.CreateProduct;

public sealed class CreateProductCommandHandler(CatalogDbContext catalogDbContext) : IRequestHandler<CreateProductCommand, Result<CreateProductResponse>>
{
    public async Task<Result<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productResult = CreateNewProduct(request.Product);

        if (!productResult.Success)
        {
            return Result<CreateProductResponse>.Failure(productResult.Error);
        }

        var product = productResult.Value;

        catalogDbContext.Products.Add(product);
        await catalogDbContext.SaveChangesAsync(cancellationToken);

        return Result<CreateProductResponse>.Ok(new CreateProductResponse(product.Id));
    }

    private static Result<Product> CreateNewProduct(ProductDto productDto)
    {
        return Product.Create(Guid.NewGuid(), productDto.Name, productDto.ImageFile, productDto.Description, productDto.Price);
    }
}
