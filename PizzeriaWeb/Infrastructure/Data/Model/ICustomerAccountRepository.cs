using System.Collections.Generic;
using SQLHomeWork.Domain;

namespace PizzeriaWeb.Infrastructure.Data.CustomerAccountModel
{
    public interface ICustomerAccountRepository
    {
        List<CustomerAccount> GetAll();
        CustomerAccount GetByLogin(string login);
        CustomerAccount GetById(int id);
        int Update(CustomerAccount customerAccount);
        void Delete(CustomerAccount customerAccount);

        int Create(CustomerAccount customerAccount);

    }
}
