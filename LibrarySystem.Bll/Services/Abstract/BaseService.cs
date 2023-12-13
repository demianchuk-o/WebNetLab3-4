using AutoMapper;
using LibrarySystem.DAL.UnitOfWork.Abstract;

namespace LibrarySystem.Bll.Services.Abstract;

public abstract class BaseService
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IMapper Mapper;
    
    protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }
}