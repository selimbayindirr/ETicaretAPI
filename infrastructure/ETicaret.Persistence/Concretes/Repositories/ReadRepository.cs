using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ETicaretAPI.Persistence.Concretes.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        //  =>  Table;//tracking kullanacağım için scope lara geçtim
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();//false ise takip etmesin
            return query;

        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        // =>await  Table.FirstOrDefaultAsync(expression); tracking
        {
            var query = Table.AsQueryable(); //ÖNCE BUNA ÇEVİRMEN GEREKİR YOKSA DBCONTEXTTEN TALEP ETMEN GEREKLİ
            if (!tracking)
                query = query.AsNoTracking();//false ise takip etmesin
            return await query.FirstOrDefaultAsync(expression); ;

        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        //=>Table.Where(expression);
        {
            var query = Table.Where(expression);
            if (!tracking)
                query = query.AsNoTracking();//false ise takip etmesin
            return query;
        }
        public async Task<T> GETByIdAsync(string id, bool tracking = true)
        // =>Table.FirstOrDefaultAsync(data =>data.Id == Guid.Parse(id));
        //{Table.FirstOrDefaultAsync<T>().Id = id;}
        // => await Table.FindAsync(Guid.Parse(id));//tracking
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();//false ise takip etmesin
          //  return await query.FindAsync(Guid.Parse(id)); 
            //IQURABLE DE FİNDASYNC YOK ONUN YERİNE 
           return await query.FirstOrDefaultAsync(data => data.Id==Guid.Parse(id)); 


        }
        

    }
}
