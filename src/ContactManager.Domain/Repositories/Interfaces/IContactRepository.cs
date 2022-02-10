using ContactManager.Domain.Entities;
using ContactManager.Domain.Repositories.Interfaces.Shared;

namespace ContactManager.Domain.Repositories.Interfaces;

public interface IContactRepository : IBaseRepository<Contact>
{

}