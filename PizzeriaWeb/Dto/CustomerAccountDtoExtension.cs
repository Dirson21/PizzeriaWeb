using SQLHomeWork.Domain;

namespace PizzeriaWeb.Dto
{
    public static class CustomerAccountDtoExtension
    {
        public static CustomerAccount ConvertToCustomerAccount(this CustomerAccountDto customerDto)
        {
            return new CustomerAccount
            {
                Id = customerDto.Id,
                Login = customerDto.Login,
                Password = customerDto.Password,
                Balance = customerDto.Balance
            };
          
       
        }
        public static CustomerAccountDto ConvertToCustomerAccountDto(this CustomerAccount customer)
        {
            return new CustomerAccountDto {
               Id = customer.Id,
               Login = customer.Login, 
               Password = customer.Password,
               Balance = customer.Balance 
            };
        }
    }
}
