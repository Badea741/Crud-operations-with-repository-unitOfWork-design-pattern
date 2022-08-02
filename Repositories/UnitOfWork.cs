using Project.Models;

namespace Project.Repositories;
public class UnitOfWork : IDisposable
{
    readonly DatabaseContext _db;
    public ICustomerRepository customerRepository { get; set; }
    public readonly IPropertyRepository propertyRepository;
    public UnitOfWork(DatabaseContext db, ICustomerRepository customerRepository, IPropertyRepository propertyRepository)
    {
        _db = db;
        this.propertyRepository = propertyRepository;
        this.customerRepository = customerRepository;
    }

    public bool Save()
    {
        try
        {
            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}