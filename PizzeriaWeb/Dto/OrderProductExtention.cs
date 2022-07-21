using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Dto
{
    public static class OrderProductExtention
    {
        public static OrderProduct ConvertToOrderProduct(this OrderProductDto orderProductDto)
        {
            return new OrderProduct
            {
                OrderId = orderProductDto.OrderId,
                ProductId = orderProductDto.ProductId,
            };
        }
        public static OrderProductDto ConvertToOrderProductDto(this OrderProduct orderProduct)
        {
            return new OrderProductDto
            {
                OrderId = orderProduct.OrderId,
                ProductId = orderProduct.ProductId
            };
            
        }
    }
}
