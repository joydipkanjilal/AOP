using Autofac.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Autofac.Demo
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "DELL Laptop", Description = "Laptop", Price = 2500 },
            new Product { Id = 2, Name = "HP Color Printer", Description = "Printer", Price = 800 },
            new Product { Id = 3, Name = "Microsoft Mouse", Description = "Mouse", Price = 500 });
        }
    }
}
