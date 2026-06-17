using Mini_E_Commerce_API.DTOs;
using Mini_E_Commerce_API.Models;

namespace Mini_E_Commerce_API.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        ProductDto GetProduct(int productId);
        void AddProduct(ProductDto product);
        void UpdateProduct(int productId, ProductDto product);
        void SoftDeleteProduct(int productId);
    }
}
