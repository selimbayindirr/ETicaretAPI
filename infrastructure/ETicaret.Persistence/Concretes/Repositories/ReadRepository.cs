using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()=>  Table;
        
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
            =>await  Table.FirstOrDefaultAsync(expression);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
                =>Table.Where(expression);
        public Task<T> GETByIdAsync(Guid id)
        {
            throw new NotImplementedException();
            //Table.FirstOrDefaultAsync<T>().Id = id;
        }

    }
}
