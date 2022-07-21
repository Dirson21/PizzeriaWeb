using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Infrastructure.Data.Model
{
    public interface IProductRepository
    {
        Product GetByName(string name);

        Product GetById(int id);
        List<Product> GetAll();

        int Create(Product product);

        int Update(Product newProduct);
        void Delete(Product newProduct);
    }
}
