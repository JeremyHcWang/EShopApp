using CustomerAPI.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI_Infrastructure.Data;

public class EShopDbContext : DbContext
{
    public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }
}