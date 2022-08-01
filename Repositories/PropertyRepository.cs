using Project.Models;

namespace Project.Repositories;
public class PropertyRepository : IPropertyRepository, IDisposable
{
    readonly DatabaseContext db;
    public PropertyRepository(DatabaseContext db)
    {
        this.db = db;
    }
    public void Add(Property property)
    {
        db.Properties.Add(property);
    }

    public void Delete(Property property)
    {
        db.Properties.Remove(property);
    }

    public bool DeleteById(Guid id)
    {
        try
        {
            db.Properties.Remove(db.Properties.FirstOrDefault(p => p.Id == id)!);
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
    }

    public IQueryable<Property> GetAll()
    {
        return db.Properties;
    }

    public Property GetById(Guid id)
    {

        return db.Properties.FirstOrDefault(p => p.Id == id) ?? new Property { };
    }

    public void Update(Property property)
    {
        db.Properties.Update(property);
    }
}
