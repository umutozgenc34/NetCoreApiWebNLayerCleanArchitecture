using App.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Persistence;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
{
    protected AppDbContext Context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();
    public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public ValueTask<T?> GetByIdAsync(int id) => _dbSet.FindAsync(id);


    public void Update(T entity) => _dbSet.Update(entity);


    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

    public Task<List<T>> GetAllAsync()
    {
        return _dbSet.ToListAsync();    
    }

    public Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize)
    {
        return _dbSet.Skip((pageNumber-1) * pageSize).Take(pageSize).ToListAsync(); 
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.AnyAsync(predicate);
    }
}
