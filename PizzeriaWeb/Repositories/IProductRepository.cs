using SQLHomeWork.Domain;

namespace SQLHomeWork.Repositories
{
    interface IProductRepository
    {
        Product GetByName(string name);

        Product GetById(int id);

        void Update(Product newProduct);
        void Delete(Product newProduct);
    }
}
