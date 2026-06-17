using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_E_Commerce_API.Models;

namespace Mini_E_Commerce_API.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Status)
                .HasConversion<string>()
                .HasMaxLength(30)
                .HasDefaultValue(OrderStatus.Pending);
            builder.Property(p => p.TotalAmount)
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.PlacedAt)
                .HasDefaultValueSql("GETUTCDATE()");
            builder.HasIndex(p => p.Status)
                .HasFilter("[Status] = 'Pending'")
                .HasDatabaseName("IX_Orders_PendingStatus");
            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Order
                {
                    OrderId = 1,
                    UserId = 2, 
                    PlacedAt = new DateTime(2023, 10, 1),
                    Status = OrderStatus.Pending,
                    TotalAmount= 16000
            
                }
            );
        }
    }
}
