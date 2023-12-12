using AutoMapper;
using LibrarySystem.DAL.Entities.Abstract;
using LibrarySystem.DAL.Repositories.Abstract;

namespace LibrarySystem.Bll.Services.Abstract;

public abstract class BaseService<TEntity, TRepository>
    where TEntity : class, IIdentity
    where TRepository : IRepository<TEntity>
{
    protected readonly IRepository<TEntity> Repository;
    protected readonly IMapper Mapper;
    
    protected BaseService(TRepository repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }
}