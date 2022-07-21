namespace PizzeriaWeb.Domain
{
    public class OrderProduct
    {
       public int OrderId { get; set; }
       public int ProductId { get; set; }

       public Order OrderRef { get; set; }
       
       public Product ProductRef { get; set; }
    }
}
