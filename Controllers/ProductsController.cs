using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Commerce_API.DTOs;
using Mini_E_Commerce_API.Models;
using Mini_E_Commerce_API.Services;

namespace Mini_E_Commerce_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetProducts()
        {
            return Ok(productService.GetProducts());
        }
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public IActionResult GetProduct(int id)
        {
            var product = productService.GetProduct(id);
            return Ok(product);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult Create(ProductDto product)
        {
            productService.AddProduct(product);
            return Ok("Product Created Successfully");
        }
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, ProductDto product)
        {
            productService.UpdateProduct(id, product);
            return Ok("Product Updated Successfully");
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            productService.SoftDeleteProduct(id);
            return Ok() ;
        }

    }
}
