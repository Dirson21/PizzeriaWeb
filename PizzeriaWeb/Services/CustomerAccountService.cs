using PizzeriaWeb.Dto;
using SQLHomeWork.Domain;
using SQLHomeWork.Repositories;

namespace PizzeriaWeb.Services
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly ICustomerAccountRepository _customerAccountRepository;

        public CustomerAccountService(ICustomerAccountRepository customerAccountRepository)
        {
            _customerAccountRepository = customerAccountRepository;
        }

        public int CreateCustomerAccount(CustomerAccountDto customerAccount)
        {
            if (customerAccount == null)
            {
                new Exception($"{nameof(customerAccount)} is not found.");
            }
            return _customerAccountRepository.Create(customerAccount.ConverToCustomerAccount());
           
        }

        public void DeleteCustomerAccount(int customerAccountId)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount GetCustomerAccount(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerAccount> GetCustomerAccounts()
        {
            return _customerAccountRepository.GetAll();
            
        }

        public void UpdateCustomerAccount(CustomerAccountDto customerAccount)
        {
            throw new NotImplementedException();
        }
    }
}
