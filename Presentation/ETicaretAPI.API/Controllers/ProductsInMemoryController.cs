using ETicaretAPI.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsInMemoryController : ControllerBase
    {
        private readonly InMemoryIProductService _productService;
        public ProductsInMemoryController(InMemoryIProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetInMemoryProducts()
        {
            var products=_productService.GetProducts();
            return Ok(products);
        }
    }
}
