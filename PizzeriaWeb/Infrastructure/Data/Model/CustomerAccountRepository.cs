using SQLHomeWork.Domain;

namespace PizzeriaWeb.Infrastructure.Data.CustomerAccountModel
{
    public class CustomerAccountRepository : ICustomerAccountRepository
    {
        private readonly PizzeriaDbContext _dbContext;

        public CustomerAccountRepository(PizzeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CustomerAccount customerAccount)
        {
            int id = _dbContext.customerAccount.Add(customerAccount).Entity.Id;
       
            return id;
        }

        public void Delete(CustomerAccount customerAccount)
        {
            _dbContext.customerAccount.Remove(customerAccount);
        }

        public List<CustomerAccount> GetAll()
        {
            return _dbContext.customerAccount.ToList();
        }

        public CustomerAccount GetById(int id)
        {
            return _dbContext.customerAccount.SingleOrDefault(customer => customer.Id == id);
        }

        public CustomerAccount GetByLogin(string login)
        {
            return _dbContext.customerAccount.SingleOrDefault(customer => customer.Login == login);
        }

        public int Update(CustomerAccount customerAccount)
        {
            return _dbContext.customerAccount.Update(customerAccount).Entity.Id;
        }
    }
}
