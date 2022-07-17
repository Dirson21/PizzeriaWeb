using SQLHomeWork.Domain;

namespace SQLHomeWork.Repositories
{
    public interface ICustomerAccountRepository
    {
        List<CustomerAccount> GetAll();
        CustomerAccount GetByLogin(string login);
        CustomerAccount GetById(int id);
        int Update(CustomerAccount customerAccount);
        void Delete(CustomerAccount customerAccount);

        int Create(CustomerAccount customerAccount);

        List<Tuple<CustomerAccount, decimal>> GetAllTotalPrice();




    }
}
