using Project.Models;

namespace Project.Repositories;
public interface IPropertyRepository : IRepository<Property>
{
    public Property GetById(Guid id);
    public bool DeleteById(Guid id);
}