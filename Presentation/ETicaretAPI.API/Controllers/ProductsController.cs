using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository  _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpPut]
        public async Task GetTrackingTest()
        {

            Product p = await _productReadRepository.GETByIdAsync("D58B0704-B105-4617-8AC1-19EABB9F4D9E",false);
            //false olursa tracking ile yapılan çalışmalar ,işlenmesin
            p.ProductName = "Bardak";
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet]
        public async Task Get()
        {
          await  _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id=Guid.NewGuid(),ProductName="Product 1",Price=100,CreatedDate=DateTime.UtcNow,Stock=10,ProductDescription="Product 1"},
                new() {Id=Guid.NewGuid(),ProductName="Product 2",Price=200,CreatedDate=DateTime.UtcNow,Stock=20,ProductDescription="Product 2"},
                new() {Id=Guid.NewGuid(),ProductName="Product 3",Price=300,CreatedDate=DateTime.UtcNow,Stock=50,ProductDescription="Product 3"},
            });
         var count=  await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
           Product product= await _productReadRepository.GETByIdAsync(id);
            return Ok(product);
        }

  
    }
}
