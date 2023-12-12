using LibrarySystem.DAL.Entities.Abstract;
using LibrarySystem.DAL.Repositories.Abstract;

namespace LibrarySystem.Bll.Services.Abstract;

public abstract class BaseService<TEntity>
    where TEntity : class, IIdentity
{
    protected readonly IRepository<TEntity> Repository;

    protected BaseService(IRepository<TEntity> repository)
    {
        Repository = repository;
    }
}