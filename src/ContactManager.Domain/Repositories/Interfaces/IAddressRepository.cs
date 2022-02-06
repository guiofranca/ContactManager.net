using ContactManager.Domain.Entities.Shared;
using ContactManager.Domain.Repositories.Interfaces.Shared;

namespace ContactManager.Domain.Repositories.Interfaces;

public interface IAddressRepository<T> : IBaseRepository<T>, IOwnedByContactRepository<T> where T : OwnedByContactEntity
{

}