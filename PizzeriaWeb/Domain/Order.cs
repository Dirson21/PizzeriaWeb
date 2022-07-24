namespace PizzeriaWeb.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime TimeOrder { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public CustomerAccount CustomerAccount { get; set; }
    }
}
