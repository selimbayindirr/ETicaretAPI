using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Context
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {
            //IOC Controller ile doldurulacaktır.
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        //interceptor
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)//sen hangi savechanges turunu kullandıysan onu eklersin
        {
            /*
            * Amaç : insert ise createdDate update isen updated date alanı doldurulsun
            */
            //ChangeTracker :Entityler üzerinden yapılan değişiklilkerlin yakalanmasını sağlayan propertydir.Update operasyonların da Track edilen verileri yakalayıpğ elde etmenizi sağlar.
            //Entriesç:Sürece giren değişiklik yapan tüm girdiler ,Tüm BaseEntityler
          var datas= ChangeTracker
                .Entries<BaseEntity>();
            foreach (var item in datas)
            {
                 _ = item.State switch //discard yapılanması
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.UtcNow
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
