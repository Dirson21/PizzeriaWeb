using PizzeriaWeb.Dto;
using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Services
{
    public interface ICustomerAccountService
    {
        List<CustomerAccountDto> GetCustomerAccounts();
        CustomerAccountDto GetCustomerAccount(int id);
        CustomerAccountDto GetCustomerAccountByLogin(string login);
        int CreateCustomerAccount(CustomerAccountDto customerAccount);
        void DeleteCustomerAccount(int customerAccountId);
        int UpdateCustomerAccount(CustomerAccountDto customerAccount);
        List<Tuple<CustomerAccountDto, decimal>> GetTotalPriceOrders();

    }
}
