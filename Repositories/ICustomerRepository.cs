using Project.Models;

namespace Project.Repositories;
public interface ICustomerRepository : IRepository<Customer>
{
    Customer GetByPhoneNumber(string phoneNumber);
    bool DeleteByPhoneNumber(string phoneNumber);
}