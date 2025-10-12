
namespace Catalog.Features.UpdateProduct;

public sealed class UpdateProductCommandHandler(CatalogDbContext catalogDbContext) : IRequestHandler<UpdateProductCommand, Result<UpdateProductResponse>>
{
    public async Task<Result<UpdateProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await catalogDbContext.Products.FindAsync(request.Product.Id, cancellationToken);

        if (product == null)
        {
            return Result<UpdateProductResponse>.Failure("Product with given Id was not found.");
        }

        var productUpdateResult = product.Update(request.Product.Name, request.Product.ImageFile, request.Product.Description, request.Product.Price);

        if (!productUpdateResult.Success)
        {
            return Result<UpdateProductResponse>.Failure(productUpdateResult.Error);
        }

        return Result<UpdateProductResponse>.Ok(new UpdateProductResponse(productUpdateResult.Value));
    }
}
