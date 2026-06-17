using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_E_Commerce_API.Models;

namespace Mini_E_Commerce_API.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.OrderItemId);
            builder.Property(p => p.UnitPrice)
               .HasColumnType("decimal(18,2)");
            builder.Property(p => p.Quantity)
                .IsRequired();
            builder.HasIndex(i => new { i.OrderId, i.ProductId })
                .HasDatabaseName("IX_OrderItems_Order_Product");
            builder.HasOne(o => o.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p=>p.Product)
                .WithMany(p=>p.OrderItems)
                .HasForeignKey(p=>p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
        
                new OrderItem
                {
                    OrderItemId = 1,
                    OrderId = 1,   
                    ProductId = 1,  
                    Quantity = 1,
                    UnitPrice = 15000
                },
        
                new OrderItem
                {
                    OrderItemId = 2,
                    OrderId = 1,    
                    ProductId = 2,  
                    Quantity = 2,
                    UnitPrice = 500
                }
            );
        }
    }
}
