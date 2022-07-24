namespace PizzeriaWeb.Dto
{
    public class OrderProductDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public ProductDto Product { get; set; }
    }
}
