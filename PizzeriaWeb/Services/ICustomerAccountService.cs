using PizzeriaWeb.Dto;
using SQLHomeWork.Domain;

namespace PizzeriaWeb.Services
{
    public interface ICustomerAccountService
    {
        List<CustomerAccount> GetCustomerAccounts();
        CustomerAccount GetCustomerAccount(int id);
        CustomerAccount GetCustomerAccountByLogin(string login);
        int CreateCustomerAccount(CustomerAccountDto customerAccount);
        void DeleteCustomerAccount(int customerAccountId);
        int UpdateCustomerAccount(CustomerAccountDto customerAccount);


    }
}
