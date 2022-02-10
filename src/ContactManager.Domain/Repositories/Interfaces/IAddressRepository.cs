using ContactManager.Domain.Entities;
using ContactManager.Domain.Entities.Shared;
using ContactManager.Domain.Repositories.Interfaces.Shared;

namespace ContactManager.Domain.Repositories.Interfaces;

public interface IAddressRepository : IBaseRepository<Address>, IOwnedByContactRepository<Address>
{

}