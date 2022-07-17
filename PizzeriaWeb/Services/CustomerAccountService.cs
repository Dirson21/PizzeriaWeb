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
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }
            return _customerAccountRepository.Create(customerAccount.ConvertToCustomerAccount());
           
        }

        public void DeleteCustomerAccount(int customerAccountId)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount GetCustomerAccount(int id)
        {
            CustomerAccount customerAccount = _customerAccountRepository.GetById(id);
            if (customerAccount == null)
            {
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }
            return customerAccount;
            
        }

        public CustomerAccount GetCustomerAccountByLogin(string login)
        {
            CustomerAccount customerAccount = _customerAccountRepository.GetByLogin(login);
            if (customerAccount == null)
            {
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }
            return customerAccount;
        }

        public List<CustomerAccount> GetCustomerAccounts()
        {
            return _customerAccountRepository.GetAll();
            
        }

        public int UpdateCustomerAccount(CustomerAccountDto customerAccount)
        {
            if (customerAccount == null)
            {
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }
            return _customerAccountRepository.Update(customerAccount.ConvertToCustomerAccount());
        }
    }
}
