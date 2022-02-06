using ContactManager.Data.Mysql.Context;
using ContactManager.Domain.Entities;
using ContactManager.Domain.Entities.Shared;
using ContactManager.Domain.Repositories.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data.Mysql.Repositories.Shared;

public abstract class OwnedByContactRepository<T> : BaseRepository<T>, IOwnedByContactRepository<T> where T : OwnedByContactEntity
{
    protected OwnedByContactRepository(DataContext dataContext) : base(dataContext) { }

    public async Task<IEnumerable<T>> FindByContact(Contact contact)
    {
        return await Db.Set<T>()
            .Where(tes => tes.ContactId == contact.Id)
            .AsNoTracking()
            .ToListAsync();
    }
}
