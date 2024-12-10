using Microsoft.EntityFrameworkCore;
using Webshop.Domain.Interfaces;

namespace Webshop.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WebshopDbContext _context;

        public Repository(WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null) _context.Set<T>().Remove(entity);
        }
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
