using Microsoft.EntityFrameworkCore;
using ProductAPI_ApplicationCore.Contracts.RepositoryInterfaces;
using ProductAPI_ApplicationCore.Entities;
using ProductAPI_Infrastructure.Data;

namespace ProductAPI_Infrastructure.Repositories;

public class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
{
    private readonly EShopDbContext _context;
    private readonly DbSet<Product> _dbSet;
    
    public ProductRepositoryAsync(EShopDbContext context) : base(context)
    {
        _context = context;
        _dbSet = _context.Set<Product>();
    }
}