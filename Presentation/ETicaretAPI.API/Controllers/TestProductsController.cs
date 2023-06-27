using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository  _productReadRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        readonly private ICustomerReadRepository _customerReadRepository;
        readonly private  ICustomerWriteRepository _customerWriteRepository;

        public TestProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet("GetProductsListed")]
        public IActionResult GetProductsListed()
        {
          var products=  _productReadRepository.GetAll();
            return Ok(products);
        }
        [HttpGet("GetProductsAdded")]
        public async Task Get()
        {
          await  _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id=Guid.NewGuid(),ProductName="Product 1",Price=1.500F,CreatedDate=DateTime.UtcNow,Stock=10,ProductDescription="Product 1"},
                new() {Id=Guid.NewGuid(),ProductName="Product 2",Price=2.500F,CreatedDate=DateTime.UtcNow,Stock=20,ProductDescription="Product 2"},
                new() {Id=Guid.NewGuid(),ProductName="Product 3",Price=3.500F,CreatedDate=DateTime.UtcNow,Stock=50,ProductDescription="Product 3"},
            });
         var count=  await _productWriteRepository.SaveAsync();
        }
        [HttpGet("GetProduct{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GETByIdAsync(id);
            return Ok(product);
        }
        [HttpPut("GetProduct{id}")] 
        public async Task GetTrackingTest(string id)
        {

            Product p = await _productReadRepository.GETByIdAsync(id);
            //false olursa tracking ile yapılan çalışmalar ,işlenmesin
            p.ProductName = "Kola";
            await _productWriteRepository.SaveAsync();
        }

        [HttpDelete("DeleteProducts{id}")]
        public async Task<IActionResult> GetByIdRemove(string id)
        {
            var query = await _productReadRepository.GETByIdAsync(id);
           _productWriteRepository.RemoveByIdAsync(id).Wait();
            await _productWriteRepository.SaveAsync();
            return Ok();

        }
        //interceptor Test Order Table
        //BU İKİ ÖRNEK İnterceptor testi için oluşturuldu.
        //bir order eklendi ve güncellendi ekleme yapıldığında createdDate güncelleme yapıldığında updated alanları etkilendi.

        [HttpGet("OrderAdded")]
        public async Task GetOrderdded()
        {
            var customerId = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Muhiddin" });


            await _orderWriteRepository.AddAsync(new Order() { Description = "bla bla bla", Address = "Ankara,Çankaya", CustomerId=customerId });
            _orderWriteRepository.AddAsync(new Order() { Description = "bla bla bla", Address = "Ankara,Pursaklar" , CustomerId = customerId });


            await _orderWriteRepository.SaveAsync();
        }
        [HttpGet("OrderUpdated")]
        public async Task GetOrderUpdated()
        {
         Order order=await _orderReadRepository .GETByIdAsync("54781525-5AEE-497B-CDDA-08DB7736DE3B");
            order.Address = "Giresun,Çamoluk";
            await _orderWriteRepository.SaveAsync();

        }


    }
}
