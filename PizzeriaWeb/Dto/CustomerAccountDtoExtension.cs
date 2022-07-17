using SQLHomeWork.Domain;

namespace PizzeriaWeb.Dto
{
    public static class CustomerAccountDtoExtension
    {
        public static CustomerAccount ConverToCustomerAccount(this CustomerAccountDto customerDto)
        {
            return new CustomerAccount(customerDto.Id, customerDto.Login, customerDto.Password, customerDto.Balance);
       
        }
        public static CustomerAccountDto ConvertToCustomerAccountDto(this CustomerAccount customer)
        {
            return new CustomerAccountDto(customer.Id, customer.Login, customer.Password, customer.Balance);
        }
    }
}
