using PizzeriaWeb.Dto;
using SQLHomeWork.Domain;

namespace PizzeriaWeb.Services
{
    public interface ICustomerAccountService
    {
        List<CustomerAccount> GetCustomerAccounts();
        CustomerAccount GetCustomerAccount(int id);
        int CreateCustomerAccount(CustomerAccountDto customerAccount);
        void DeleteCustomerAccount(int customerAccountId);
        void UpdateCustomerAccount(CustomerAccountDto customerAccount);


    }
}
