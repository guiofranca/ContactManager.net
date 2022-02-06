using ContactManager.Data.Mysql.Context;
using ContactManager.Data.Mysql.Repositories.Shared;
using ContactManager.Domain.Entities;
using ContactManager.Domain.Repositories.Interfaces;

namespace ContactManager.Data.Mysql.Repositories;

public class ContactRepository : BaseRepository<Contact>, IContactRepository<Contact>
{
    public ContactRepository(DataContext dataContext) : base(dataContext) { }
}