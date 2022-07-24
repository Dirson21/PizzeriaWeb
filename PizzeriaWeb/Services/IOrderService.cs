using PizzeriaWeb.Domain;
using PizzeriaWeb.Dto;

namespace PizzeriaWeb.Services
{
    public interface IOrderService
    {
        List<OrderDto> GetOrders();
        List<OrderDto> GetOrdersByCustomerId(int customerId);

        int CreateOrder(OrderDto order);

        int UpdateOrder(OrderDto order);

        void DeleteOrder(int orderId);
            
        


    }
}
