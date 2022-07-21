using SQLHomeWork.Domain;

namespace PizzeriaWeb.Infrastructure.Data.CustomerAccountModel
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
