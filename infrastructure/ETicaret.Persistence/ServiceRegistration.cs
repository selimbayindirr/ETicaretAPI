using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Persistence.Concretes;
using ETicaretAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services) //Program.cs de kullanabilmel için IServiceCollection ekleriz
        {
            ///services.AddSingleton<InMemoryIProductService, ProductService>();
            //services.AddDbContext<ETicaretAPIDbContext>(option => option.UseSqlServer("Server=SELIMBAYINDIR\\ARCHITECTURE;Database=ETicaretAPI;User Id=sa;Password=Perkon123456; TrustServerCertificate=True;"));

            services.AddDbContext<ETicaretAPIDbContext>(option => option.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
