using System.Linq.Expressions;

namespace ACME.School.Core.Persistences
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> SelectAsync(Expression<Func<T, bool>> predicate);
    }
}
