using ContactManager.Domain.Entities.Shared;

namespace ContactManager.Domain.Repositories.Interfaces.Shared;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<bool> Destroy(int id);
    //Task<bool> Destroy(List<int> ids);
    Task<T?> Find(int id);
    //Task<IEnumerable<T>> Find(List<int> ids);
    Task<T> Create(T entity);
    //List<T> Create(List<T> entities);
    Task<IEnumerable<T>> All();
    Task<T> Update(T entity);
    //List<T> Update(List<T> entities);
}