using Project.Models;
using Project.Helpers;
namespace Project.Repositories;
public class MemCustomerRepository : ICustomerRepository
{
    public static List<Customer> customers = new List<Customer>();
    // public MemCustomerRepository(List<Customer> customers)
    // {
    //     this.customers = customers;
    // }
    public static List<Customer> GetInstance()
    {
        if (customers == null)
        {
            customers = new List<Customer>();
        }
        return customers;
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
        foreach (Customer c in customers.Where(c => c.PhoneNumber == customer.PhoneNumber))
        {
            c.GetUpdate(customer);
        }
    }
}
