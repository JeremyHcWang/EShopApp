using Microsoft.EntityFrameworkCore;
using ProductAPI_ApplicationCore.Entities;

namespace ProductAPI_Infrastructure.Data;

public class EShopDbContext : DbContext
{
    public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}