using AutoMapper;
using LibrarySystem.DAL.Entities.Abstract;
using LibrarySystem.DAL.Repositories.Abstract;
using LibrarySystem.DAL.UnitOfWork.Abstract;

namespace LibrarySystem.Bll.Services.Abstract;

public abstract class BaseService<TEntity, TRepository>
    where TEntity : class, IIdentity
    where TRepository : IRepository<TEntity>
{
    protected readonly IRepository<TEntity> Repository;
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IMapper Mapper;
    
    protected BaseService(TRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        Repository = repository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }
}