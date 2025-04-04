using Microsoft.EntityFrameworkCore;
using ProductTask.Entities.ProductEntities;
using ProductTask.Entities.UserEntities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) {}
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
}
