using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MVC.Demo.Challenge
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {           
            optionsBuilder.UseInMemoryDatabase(databaseName: "OrderManagementSystem")
                .LogTo(Console.WriteLine, new[] { CoreEventId.StartedTracking }, LogLevel.Debug,
                DbContextLoggerOptions.DefaultWithLocalTime | 
                DbContextLoggerOptions.SingleLine).EnableDetailedErrors().EnableSensitiveDataLogging();
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, FirstName = "Joseph", LastName = "Harris", Address = "Wairere Road, Canberra", Phone = "9234567890" },
            new Customer { Id = 2, FirstName = "Steve", LastName = "Smith", Address = "Arbutus Drive, Chicago", Phone = "5566778899" },
            new Customer { Id = 3, FirstName = "Eduardo", LastName = "Kinney", Address = "Southlands Road, London", Phone = "0987654321" },
            new Customer { Id = 4, FirstName = "George", LastName = "Nelson", Address = "Cedar Drive, Boston", Phone = "8926778899" },
            new Customer { Id = 5, FirstName = "Jennie", LastName = "Martinez", Address = "Woodrow Way, Houston", Phone = "6188954321" });        }
    }
}