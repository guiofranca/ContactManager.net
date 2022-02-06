using ContactManager.Domain.Entities.Shared;
using ContactManager.Domain.Repositories.Interfaces.Shared;

namespace ContactManager.Domain.Repositories.Interfaces;

public interface IEmailRepository<T> : IBaseRepository<T>, IOwnedByContactRepository<T> where T : OwnedByContactEntity
{

}