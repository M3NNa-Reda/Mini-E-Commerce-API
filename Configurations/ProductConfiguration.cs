using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_E_Commerce_API.Models;

namespace Mini_E_Commerce_API.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);
            builder.Property(p => p.DisplayName)
                .HasComputedColumnSql(" [Name] + ' (' + [SKU] + ')' ", stored: true);
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasIndex(p => p.SKU)
                .HasDatabaseName(" IX_Products_SKU")
                .IsUnique();
            builder.HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Laptop Dell",
                    SKU = "DELL-123",
                    Price = 15000,
                    StockQuantity = 10,
                    IsActive = true
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Mouse Wireless",
                    SKU = "MOU-999",
                    Price = 500,
                    StockQuantity = 50,
                    IsActive = true

                },
                new Product
                {
                    ProductId = 3,
                    Name = "Xiaomi Redmi Note 13",
                    SKU = "MOB-003",
                    Price = 5499,
                    StockQuantity = 80,
                    IsActive = true

                },
                new Product
                {
                    ProductId = 4,
                    Name = "Huawei Nova 11",
                    SKU = "MOB-005",
                    Price = 5400,
                    StockQuantity = 40,
                    IsActive = true
                }
            );

                }
    }
}
