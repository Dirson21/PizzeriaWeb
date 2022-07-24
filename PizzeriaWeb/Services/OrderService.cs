using PizzeriaWeb.Domain;
using PizzeriaWeb.Dto;
using PizzeriaWeb.Infrastructure.Data.Model;
using PizzeriaWeb.Infrastructure.UoW;

namespace PizzeriaWeb.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public int CreateOrder(OrderDto order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            int id = _orderRepository.Create(order.ConvertToOrder());
            _unitOfWork.SaveEntitiesAsync();
            return id;
            
        }

        public void DeleteOrder(int orderId)
        {
            Order order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                throw new Exception($"{nameof(order)} is not found.");        
            }
            _orderRepository.Delete(order);
            _unitOfWork.SaveEntitiesAsync();

        }

        public List<OrderDto> GetOrders()
        {
            return _orderRepository.GetAll().ConvertAll(x => x.ConvertToOrderDto());
        }

        public List<OrderDto> GetOrdersByCustomerId(int customerId)
        {
            return _orderRepository.GetByCustomerId(customerId).ConvertAll(x => x.ConvertToOrderDto());
        }

        public int UpdateOrder(OrderDto orderDto)
        {
           
            if (orderDto == null)
            {
                throw new Exception($"{nameof(orderDto)} is not found.");
            }
            int id = _orderRepository.Update(orderDto.ConvertToOrder());
          
            _unitOfWork.SaveEntitiesAsync();
            return id;
            
        }
    }
}
