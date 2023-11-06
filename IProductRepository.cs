using Autofac.Demo.Models;

namespace Autofac.Demo
{
    public interface IProductRepository
    {
        public List<Product> GetAll();

        public Product GetById(int id);

        public void Create(Product product);

        public void Delete(Product product);
    }
}