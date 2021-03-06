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
            .Where(t => t.DeletedAt == null)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T> Create(T entity)
    {
        entity.CreatedAt = DateTime.Now;
        entity.UpdatedAt = DateTime.Now;
        entity.DeletedAt = null;

        Db.Add(entity);
        await Db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Destroy(int id)
    {
        T entity = await Db.Set<T>().FindAsync(id);
        if(entity != null) {
            entity.DeletedAt = DateTime.Now;
            Db.Set<T>().Update(entity);
            await Db.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<T> Find(int id)
    {
        return await Db.Set<T>()
            .Where(t => t.DeletedAt == null)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<T> Update(T entity)
    {
        entity.UpdatedAt = DateTime.Now;
        Db.Set<T>().Update(entity);
        await Db.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Restore(T entity)
    {
        if(entity.DeletedAt != null) {
            entity.DeletedAt = null;
            entity.UpdatedAt = DateTime.Now;
            Db.Set<T>().Update(entity);
            await Db.SaveChangesAsync();
        }
        return entity;
    }

    public async Task<T> FindWithTrashed(int id)
    {
        return await Db.Set<T>()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<T>> AllWithTrashed()
    {
        return await Db.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }
}