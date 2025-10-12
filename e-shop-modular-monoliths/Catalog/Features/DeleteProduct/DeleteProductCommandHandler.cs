
namespace Catalog.Features.DeleteProduct;

public sealed class DeleteProductCommandHandler(CatalogDbContext catalogDbContext) : IRequestHandler<DeleteProductCommand, Result<DeleteProductResponse>>
{
    public async Task<Result<DeleteProductResponse>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await catalogDbContext.Products.FindAsync(request.Id, cancellationToken);

        if (product == null)
        {
            return Result<DeleteProductResponse>.Failure("Product was not found in a database.");
        }

        catalogDbContext.Products.Remove(product);
        await catalogDbContext.SaveChangesAsync();

        return Result<DeleteProductResponse>.Ok(new DeleteProductResponse(product));
    }
}
