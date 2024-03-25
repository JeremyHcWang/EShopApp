using Microsoft.EntityFrameworkCore;
using OrderAPI_ApplicationCore.Contracts.RepositoryInterfaces;
using OrderAPI_Infrastructure.Data;

namespace OrderAPI_Infrastructure.Repositories;

public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
{
    private readonly EShopDbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public BaseRepositoryAsync(EShopDbContext context) 
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public async Task<int> InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            return 0; // No entity found with the given ID.
        }
    
        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async ValueTask<T?> GetByIdAsync(int id)
    {
        // Attempt to find the entity by ID. The result might be null.
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }
}