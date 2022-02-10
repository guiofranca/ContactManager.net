using ContactManager.Data.Mysql.Context;
using ContactManager.Data.Mysql.Repositories.Shared;
using ContactManager.Domain.Entities;
using ContactManager.Domain.Repositories.Interfaces;

namespace ContactManager.Data.Mysql.Repositories;

public class EmailRepository : OwnedByContactRepository<Email>, IEmailRepository
{
    public EmailRepository(DataContext dataContext) : base(dataContext) { }
}