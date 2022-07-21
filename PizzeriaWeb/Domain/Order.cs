namespace PizzeriaWeb.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime TimeOrder { get; set; }

        public List<OrderProduct> OrderProducts => _products;
        private List<OrderProduct> _products = new List<OrderProduct>();
        public CustomerAccount CustomerAccountRef { get; set; }
    }
}
