
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

        public void GetAll()
        {
         /*   var result = _dbContext.customerAccount.Join(_dbContext.order, customer => customer.Id, order => order.CustomerId, (customer, order) => new { customer, order })
                .Join(_dbContext.orderProduct, combinedEntry => combinedEntry.order.Id, orderProduct => orderProduct.OrderId, (combinedEntry, orderPruct) => new { combinedEntry, orderPruct })
                .Join(_dbContext.product, combainedEntry => combainedEntry.combinedEntry)*/
                
                
    
            throw new NotImplementedException();
        }
    }
}
