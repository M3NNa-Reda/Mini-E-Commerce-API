using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_E_Commerce_API.Models;

namespace Mini_E_Commerce_API.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FullName)
                .HasColumnName("full_name")
                .IsRequired()
                .HasMaxLength(150)
                .HasComment("Customer full legal name");
            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasIndex(e => e.Email)
                .HasDatabaseName("IX_Customers_Email")
                .IsUnique();
            builder.HasData(
                new User
                {
                    UserId = 1,
                    FullName = "System Admin",
                    Email = "admin@store.com",
                    Password = "admin123",
                    Role = "Admin"
                },
                new User
                {
                    UserId = 2,
                    FullName = "John Doe",
                    Email = "customer@gmail.com",
                    Password = "ABC123",
                    Role = "Customer"
                }
            );
        }
    }
}
