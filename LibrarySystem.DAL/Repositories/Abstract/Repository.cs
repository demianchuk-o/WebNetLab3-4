using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Entities.Abstract;
using LibrarySystem.DAL.Specifications;
using LibrarySystem.DAL.Specifications.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DAL.Repositories.Abstract;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IIdentity
{
    protected readonly LibraryDbContext Context;

    protected Repository(DbContext context)
    {
        Context = (LibraryDbContext) context;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var entity = await Context.Set<TEntity>().FindAsync(id);
        
        if (entity is not null)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
    
    protected IQueryable<TEntity> ApplySpecification(
        Specification<TEntity> specification)
    {
        return SpecificationEvaluator.GetQuery(
            Context.Set<TEntity>().AsQueryable(), 
            specification);
    }
}