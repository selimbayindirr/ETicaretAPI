using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Concretes;
using ETicaretAPI.Persistence.Concretes.Repositories;
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
            #region 1
            //services.AddDbContext<ETicaretAPIDbContext>(option => option.UseSqlServer(Configuration.ConnectionString),ServiceLifetime.Singleton); 

            //services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            //services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            //services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            //services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            //services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            //services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
            //services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
            #endregion
            #region 2   
            services.AddDbContext<ETicaretAPIDbContext>(option => option.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            #endregion




        }
    }
}
