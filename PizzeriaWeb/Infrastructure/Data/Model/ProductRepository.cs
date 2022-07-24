using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Infrastructure.Data.Model
{
    public class ProductRepository : IProductRepository
    {
        private readonly PizzeriaDbContext _dbContext;

        public ProductRepository(PizzeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Product product)
        {
            

            int id = _dbContext.product.Add(product).Entity.Id;
            
            return id;
        }

        public void Delete(Product product)
        {
            _dbContext.Remove(product);
        }

        public List<Product> GetAll()
        {
       

            return _dbContext.product.ToList();
        }

        public Product GetById(int id)
        {
            return _dbContext.product.SingleOrDefault(product => product.Id == id);
        }

        public Product GetByName(string name)
        {
            return _dbContext.product.SingleOrDefault(product => product.Name == name);
        }

        public int Update(Product product)
        {
           return _dbContext.product.Update(product).Entity.Id;
        }
    }
}
