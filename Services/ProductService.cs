using Mini_E_Commerce_API.Data;
using Mini_E_Commerce_API.DTOs;
using Mini_E_Commerce_API.Models;

namespace Mini_E_Commerce_API.Services
{
    public class ProductService(ApplicationDbContext context) : IProductService
    {
        public IEnumerable<ProductDto> GetProducts()
        {
            var products = context.Products
                .Select(x => new ProductDto
                {
                    Id = x.ProductId,
                    Name = x.Name,
                    SKU = x.SKU,
                    Price = x.Price,
                    StockQuantity = x.StockQuantity,
                    IsActive = x.IsActive

                }).ToList();

            return products;
        }
        
        public ProductDto GetProduct(int productId)
        {
            var product = context.Products
                .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                var productDto = new ProductDto
                {
                    Id = product.ProductId,
                    Name = product.Name,
                    SKU = product.SKU,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    IsActive = product.IsActive
                };
                return productDto;
            }
            return null;
        }
        public void AddProduct(ProductDto product)
        {

            var p = new Product
            {
                Name = product.Name,
                SKU = product.SKU,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive
            };
            context.Products.Add(p);
            context.SaveChanges();
        }
        public void UpdateProduct(int productId, ProductDto product)
        {
            var existingproduct = context.Products.FirstOrDefault(x => x.ProductId == productId);
            if(existingproduct != null)
            {
                existingproduct.Name=product.Name;
                existingproduct.SKU=product.SKU;
                existingproduct.Price=product.Price;
                existingproduct.StockQuantity=product.StockQuantity;
                existingproduct.IsActive=product.IsActive;
                context.SaveChanges();
            }
                
        }
        public void SoftDeleteProduct(int productId)
        {
            var existingproduct=context.Products.FirstOrDefault(x=> x.ProductId == productId);
            if (existingproduct != null)
            {
                existingproduct.IsActive= false;
                context.SaveChanges();
            }

        }

        
    }
}
