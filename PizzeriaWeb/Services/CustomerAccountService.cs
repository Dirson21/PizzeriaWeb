using PizzeriaWeb.Dto;
using PizzeriaWeb.Infrastructure.UoW;
using SQLHomeWork.Domain;
using PizzeriaWeb.Infrastructure.Data.CustomerAccountModel;

namespace PizzeriaWeb.Services
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly ICustomerAccountRepository _customerAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerAccountService(ICustomerAccountRepository customerAccountRepository, IUnitOfWork unitOfWork)
        {
            _customerAccountRepository = customerAccountRepository;
            _unitOfWork = unitOfWork;
        }

        public int CreateCustomerAccount(CustomerAccountDto customerAccount)
        {
            if (customerAccount == null)
            {
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }
            
            int id = _customerAccountRepository.Create(customerAccount.ConvertToCustomerAccount());
            _unitOfWork.SaveEntitiesAsync();
            return id;
           
        }

        public void DeleteCustomerAccount(int customerAccountId)
        {
            CustomerAccount customerAccount = _customerAccountRepository.GetById(customerAccountId);
            if (customerAccount == null)
            {
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }  
            _customerAccountRepository.Delete(customerAccount);
            _unitOfWork.SaveEntitiesAsync();

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
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentException($"\"{nameof(login)}\" не может быть неопределенным или пустым.", nameof(login));
            }

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
            throw new NotImplementedException();

            /*return _customerAccountRepository.GetAllTotalPrice().ConvertAll(s =>
                new Tuple<CustomerAccountDto, decimal>(s.Item1.ConvertToCustomerAccountDto(), s.Item2));*/
        }

        public int UpdateCustomerAccount(CustomerAccountDto customerAccount)
        {
            if (customerAccount == null)
            {
                throw new Exception($"{nameof(customerAccount)} is not found.");
            }
            int id = _customerAccountRepository.Update(customerAccount.ConvertToCustomerAccount());
            _unitOfWork.SaveEntitiesAsync();
            return id;
        }
    }
}
