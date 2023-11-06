using Autofac.Demo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Autofac.Demo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase("OrderManagementSystem")
                .Options;

            _context = new ProductDbContext(options);
            _context.Database.EnsureCreated();
        }
        public List<Product> GetAll() => _context.Products.ToList<Product>();
        public Product GetById(int id) => _context.Products.SingleOrDefault(p => p.Id == id);
        public void Create(Product product) => _context.Products.Add(product);
        public void Delete(Product product) => _context.Products.Remove(product);
    }

}
