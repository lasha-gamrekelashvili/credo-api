using credo_domain.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace credo_infrastructure.Persistence.Base;

public class Repository<T> : IRepository<T> where T : class 
{
    private readonly DbContext _context;
    protected readonly DbSet<T> DbSet;

    public Repository(DbContext context)
    {
        _context = context;
        DbSet = context.Set<T>();
    }
    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetById(Guid id)
    {
        return await DbSet.FindAsync(id) ?? throw new InvalidOperationException();

    }
    
    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }
}