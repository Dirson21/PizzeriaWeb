using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Dto
{
    public static class OrderDtoExtention
    {
        public static Order ConvertToOrder(this OrderDto orderDto)
        {
            return new Order
            {
                Id = orderDto.Id,
                CustomerId = orderDto.CustomerId,
                TimeOrder = orderDto.TimeOrder
            };

        }
        public static OrderDto ConvertToOrderDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                TimeOrder = order.TimeOrder
            };
        }
    }
}
