using Project.Models;

namespace Project.Repositories;
public class MemCustomerRepository : ICustomerRepository
{
    public ICollection<Customer> customers;
    public MemCustomerRepository()
    {
        customers = new List<Customer>();
    }
    public void Add(Customer customer)
    {
        customers.Add(customer);
    }

    public void Delete(Customer customer)
    {
        customers.Remove(customer);
    }

    public bool DeleteByPhoneNumber(string phoneNumber)
    {
        try
        {
            customers.Remove(customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber)!);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IQueryable<Customer> GetAll()
    {
        return customers.AsQueryable();
    }

    public Customer GetByPhoneNumber(string phoneNumber)
    {
        return customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber)!;
    }

    public void Update(Customer customer)
    {
        this.DeleteByPhoneNumber(customer.PhoneNumber);
        customers.Add(customer);
    }
}
