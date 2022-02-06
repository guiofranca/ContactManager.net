using ContactManager.Domain.Entities;
using ContactManager.Domain.Entities.Shared;

namespace ContactManager.Domain.Repositories.Interfaces.Shared;

public interface IOwnedByContactRepository<T> where T : OwnedByContactEntity
{
    Task<IEnumerable<T>> FindByContact(Contact c);
}