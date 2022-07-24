

using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Infrastructure.Data.Model
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        List<Order> GetByCustomerId(int customerId);

        Order GetById(int id);

        int Create(Order order);
        int Update(Order order);

        void Delete(Order order);



    }
}
