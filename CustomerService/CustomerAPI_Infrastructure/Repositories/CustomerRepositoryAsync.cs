using CustomerAPI_Infrastructure.Data;
using CustomerAPI.ApplicationCore.Contracts.RepositoryInterfaces;
using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI_Infrastructure.Repositories;

public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
{
    private readonly EShopDbContext _context;
    private readonly DbSet<Customer> _dbSet;
    
    public CustomerRepositoryAsync(EShopDbContext context) : base(context)
    {
        _context = context;
        _dbSet = _context.Set<Customer>();
    }

    public async Task<IEnumerable<Customer>> GetCustomerByCityAsync(string city)
    {
        return await _dbSet.Where(c => c.City == city)
            .ToListAsync();
    }
}