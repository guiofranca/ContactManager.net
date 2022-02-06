using ContactManager.Domain.Entities.Shared;
using ContactManager.Domain.Repositories.Interfaces.Shared;

namespace ContactManager.Domain.Repositories.Interfaces;

public interface IContactRepository<T> : IBaseRepository<T> where T : BaseEntity
{

}