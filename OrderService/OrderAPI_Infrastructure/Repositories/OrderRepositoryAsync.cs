using Microsoft.EntityFrameworkCore;
using OrderAPI_ApplicationCore.Contracts.RepositoryInterfaces;
using OrderAPI_ApplicationCore.Entities;
using OrderAPI_Infrastructure.Data;

namespace OrderAPI_Infrastructure.Repositories;

public class OrderRepositoryAsync : BaseRepositoryAsync<Order>, IOrderRepositoryAsync
{
    private readonly EShopDbContext _context;
    private readonly DbSet<Order> _dbSet;
    
    public OrderRepositoryAsync(EShopDbContext context) : base(context)
    {
        _context = context;
        _dbSet = _context.Set<Order>();
    }
}