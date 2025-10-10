namespace Catalog.Data.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x=> x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Description).HasMaxLength(299);

        builder.Property(x => x.Categories).IsRequired();

        builder.Property(x => x.ImageFile).HasMaxLength(100);

        builder.Property(x => x.Price).IsRequired();
    }
}
