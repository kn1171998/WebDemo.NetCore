using Microsoft.EntityFrameworkCore;
using PayCompute.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Service
{
    public abstract class RepositoryBaseService<T> : IBaseService<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> dbSet;

        //protected ApplicationDbContext DbContext
        //{
        //    get { return _context; }
        //}
        protected RepositoryBaseService(ApplicationDbContext context)
        {
            this._context = context;
            dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = GetById(id);
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
       => dbSet.AsQueryable();

        public T GetById(int id)
        => dbSet.Find(id);

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var entity = GetById(id);
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}