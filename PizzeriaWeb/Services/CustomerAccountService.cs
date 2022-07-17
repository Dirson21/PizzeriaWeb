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
            CustomerAccount customerAccount = _customerAccountRepository.GetById(customerAccountId);
            if (customerAccount == null)
            {
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }  
            _customerAccountRepository.Delete(customerAccount);
        }

        public CustomerAccountDto GetCustomerAccount(int id)
        {
            CustomerAccount customerAccount = _customerAccountRepository.GetById(id);
            if (customerAccount == null)
            {
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }
            return customerAccount.ConvertToCustomerAccountDto();
            
        }

        public CustomerAccountDto GetCustomerAccountByLogin(string login)
        {
            CustomerAccount customerAccount = _customerAccountRepository.GetByLogin(login);
            if (customerAccount == null)
            {
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }
            return customerAccount.ConvertToCustomerAccountDto();
        }

        public List<CustomerAccountDto> GetCustomerAccounts()
        {
            return _customerAccountRepository.GetAll().ConvertAll(s => s.ConvertToCustomerAccountDto());
            
        }

        public List<Tuple<CustomerAccountDto, decimal>> GetTotalPriceOrders()
        {

            return _customerAccountRepository.GetAllTotalPrice().ConvertAll(s =>
                new Tuple<CustomerAccountDto, decimal>(s.Item1.ConvertToCustomerAccountDto(), s.Item2));
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
