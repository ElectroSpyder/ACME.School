using ACME.School.Core.Domain.Context;
using ACME.School.Core.Persistences;
using Microsoft.EntityFrameworkCore;

namespace ACME.School.Core.Repositories
{
    /// <summary>
    /// for CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly SqlDbContext _context;

        public BaseRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>>     ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
