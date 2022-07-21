
namespace PizzeriaWeb.Domain
{
    public class CustomerAccount
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }

        public List<Order> Orders => _orders;
        private List<Order> _orders = new List<Order>();


    }
}
