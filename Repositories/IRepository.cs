using Microsoft.EntityFrameworkCore;
namespace Project.Repositories;
public interface IRepository<TEntity> where TEntity : class
{
    public void Add(TEntity entity);
    public IQueryable<TEntity> GetAll();
    public void Update(TEntity entity);
    public void Delete(TEntity entity);

}