using ContactManager.Domain.Entities.Shared;
using ContactManager.Domain.Repositories.Interfaces.Shared;

namespace ContactManager.Domain.Repositories.Interfaces;

public interface IPhoneRepository<T> : IBaseRepository<T>, IOwnedByContactRepository<T> where T : OwnedByContactEntity
{

}