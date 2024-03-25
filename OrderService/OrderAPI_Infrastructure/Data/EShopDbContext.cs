using Microsoft.EntityFrameworkCore;
using OrderAPI_ApplicationCore.Entities;

namespace OrderAPI_Infrastructure.Data;

public class EShopDbContext : DbContext
{
    public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
}