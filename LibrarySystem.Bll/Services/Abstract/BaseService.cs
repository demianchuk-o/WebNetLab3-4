using AutoMapper;
using LibrarySystem.DAL.Entities.Abstract;
using LibrarySystem.DAL.Repositories.Abstract;
using LibrarySystem.DAL.UnitOfWork.Abstract;

namespace LibrarySystem.Bll.Services.Abstract;

public abstract class BaseService<TEntity>
    where TEntity : class, IIdentity
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IMapper Mapper;
    
    protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }
}