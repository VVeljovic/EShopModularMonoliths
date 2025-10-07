namespace Basket.Models;

public class Product : AggregateRoot
{
    private readonly List<string> _categories = [];

    public IReadOnlyCollection<string> Categories => _categories.AsReadOnly();

    public string Name { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public string ImageFile { get; private set; } = default!;

    public decimal Price { get; private set; }

    public static Result<Product> Create(Guid id, string name, string imageFile, string description, decimal price)
    {
        if (string.IsNullOrEmpty(name))
        {
            return Result<Product>.Failure("Name of product is missing.");
        }

        if (price <= 0)
        {
            return Result<Product>.Failure("Price should be greater than zero");
        }

        var product = new Product
        {
            Id = id,
            Name = name,
            Description = description,
            ImageFile = imageFile,
            Price = price
        };

        product.AddDomainEvent(new ProductCreatedDomainEvent(product));

        return Result<Product>.Ok(product);
    }

    public Result<Product> Update(string name, string imageFile, string description, decimal price)
    {
        if (string.IsNullOrEmpty(name))
        {
            return Result<Product>.Failure("Name of product is missing.");
        }

        if (price <= 0)
        {
            return Result<Product>.Failure("Price should be greater than zero");
        }

        Name = name;
        ImageFile = imageFile;
        Description = description;
        Price = price;

        AddDomainEvent(new ProductUpdatedDomainEvent(this));

        return Result<Product>.Ok(this);
    }
}
