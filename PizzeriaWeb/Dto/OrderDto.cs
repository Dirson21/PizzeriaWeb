using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime TimeOrder { get; set; }

        public CustomerAccountDto CustomerAccountDto { get; set; }
        public List<OrderProductDto> OrderProductsDto { get; set; }
    }
}
