using ContactManager.Domain.Entities;
using ContactManager.Domain.Repositories.Interfaces.Shared;

namespace ContactManager.Domain.Repositories.Interfaces;

public interface IEmailRepository : IBaseRepository<Email>, IOwnedByContactRepository<Email>
{

}