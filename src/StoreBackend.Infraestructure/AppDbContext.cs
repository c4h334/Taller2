using Microsoft.EntityFrameworkCore;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Tabla Products
        public DbSet<Product> Products { get; set; }

        // Tabla Users
        public DbSet<User> Users { get; set; }
    }
}