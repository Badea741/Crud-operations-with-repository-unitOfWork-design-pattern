using Project.Models;
namespace Project.Repositories;
public class CustomerRepository : ICustomerRepository, IDisposable
{
    readonly DatabaseContext db;
    public CustomerRepository(DatabaseContext db)
    {
        this.db = db;
    }
    public void Add(Customer customer)
    {
        db.customers.Add(customer);
    }
    public Customer GetByPhoneNumber(string phoneNumber)
    {
        return db.customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber) ?? new Customer { };
    }
    public IQueryable<Customer> GetAll()
    {
        return db.customers;
    }
    public void Update(Customer customer)
    {
        db.customers.Update(customer);
    }
    public void Delete(Customer customer)
    {
        db.customers.Remove(customer);
    }
    public bool DeleteByPhoneNumber(string phoneNumber)
    {
        try
        {
            db.customers.Remove(db.customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber)!);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool SaveChanges()
    {
        try
        {
            db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public void Dispose()
    {
        db.Dispose();
        GC.SuppressFinalize(this);
    }
}