using LibrarySystem.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DAL.Repositories.Abstract;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IIdentity
{
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(DbContext context)
    {
        DbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var entity = await DbSet.FindAsync(id);
        
        if (entity is not null)
        {
            DbSet.Remove(entity);
        }
    }
}