using credo_domain.Models.Base;

namespace credo_infrastructure.Persistence.Base;

public interface IRepository<T> where T : class 
{
    Task AddAsync(T entity);

    Task UpdateAsync(T entity);
    Task<T> GetById(Guid id);
    Task<List<T>> GetAllAsync();
}