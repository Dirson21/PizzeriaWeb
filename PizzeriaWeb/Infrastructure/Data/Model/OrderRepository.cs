
using Microsoft.EntityFrameworkCore;
using PizzeriaWeb.Domain;


namespace PizzeriaWeb.Infrastructure.Data.Model
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzeriaDbContext _dbContext;

        public OrderRepository(PizzeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Order order)
        {
            CustomerAccount customerAccount = _dbContext.customerAccount.SingleOrDefault(x => x.Id == order.CustomerId);
            if (customerAccount == null)
            {
                throw new ArgumentNullException($"Пользователя с Id={order.CustomerId} не существует");
            }
            
            //order.CustomerAccount = customerAccount;


            return _dbContext.order.Add(order).Entity.Id;
        }

        public void Delete(Order order)
        {
            _dbContext.Remove(order);
        }

        public List<Order> GetAll()
        {
            var result = _dbContext.order.Include(x => x.CustomerAccount).Include(x => x.OrderProducts).ThenInclude(x => x.Product).ToList();

            return result;
   
        }

        public List<Order> GetByCustomerId(int customerId)
        {
            return _dbContext.order.Include(x => x.CustomerAccount).Include(x => x.OrderProducts).ThenInclude(x => x.Product).Where(x => x.CustomerId == customerId).ToList();
        }

        public Order GetById(int id)
        {
            return _dbContext.order.Include(x => x.CustomerAccount).Include(x => x.OrderProducts).ThenInclude(x => x.Product).SingleOrDefault(x => x.Id == id);
        }

        public int Update(Order order)
        {
            int id = _dbContext.order.Update(order).Entity.Id;
   
            

            return _dbContext.Update(order).Entity.Id;

        }
    }
}
