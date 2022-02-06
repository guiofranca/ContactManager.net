using ContactManager.Data.Mysql.Context;
using ContactManager.Domain.Entities.Shared;
using ContactManager.Domain.Repositories.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data.Mysql.Repositories.Shared;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DataContext Db;

    public BaseRepository(DataContext dataContext)
    {
        Db = dataContext;
    }
    public async Task<IEnumerable<T>> All()
    {
        return await Db.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T> Create(T entity)
    {
        Db.Add(entity);
        await Db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Destroy(int id)
    {
        T entity = await Db.Set<T>().FindAsync(id);
        if(entity != null) {
            Db.Set<T>().Remove(entity);
            return true;
        }
        return false;
    }

    public async Task<T> Find(int id)
    {
        return await Db.Set<T>().FindAsync(id);
    }

    public async Task<T> Update(T entity)
    {
        Db.Set<T>().Update(entity);
        await Db.SaveChangesAsync();
        return entity;
    }
}