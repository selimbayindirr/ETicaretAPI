using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : InMemoryIProductService
    {
        public List<Product> GetProducts() =>new()
        {
            new () {Id=Guid.NewGuid(),ProductName="Product 1",ProductDescription="30*30",Stock=100,Price=10,CreatedDate=DateTime.UtcNow} ,
            new () {Id=Guid.NewGuid(),ProductName="Product 2",ProductDescription="30*30",Stock=100,Price=9,CreatedDate=DateTime.UtcNow} ,
            new () {Id=Guid.NewGuid(),ProductName="Product 3",ProductDescription="30*30",Stock=100,Price=19,CreatedDate=DateTime.UtcNow} ,
            new () {Id=Guid.NewGuid(),ProductName="Product ",ProductDescription="30*30",Stock=100,Price=8,CreatedDate=DateTime.UtcNow} ,
            new () {Id=Guid.NewGuid(),ProductName="Product 4",ProductDescription="30*30",Stock=100,Price=77,CreatedDate=DateTime.UtcNow} ,
            new () {Id=Guid.NewGuid(),ProductName="Product 5",ProductDescription="30*30",Stock=100,Price=63,CreatedDate=DateTime.UtcNow} ,

        };
    }
}
