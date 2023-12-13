using AutoMapper;
using LibrarySystem.Bll.Exceptions;
using LibrarySystem.Bll.Models;
using LibrarySystem.Bll.Services.Abstract;
using LibrarySystem.Common.Search;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories.Abstract;
using LibrarySystem.DAL.UnitOfWork.Abstract;

namespace LibrarySystem.Bll.Services;

public class BookService : BaseService<Book, IBookRepository>, IBookService
{
    public BookService(IBookRepository repository, IUnitOfWork unitOfWork, IMapper mapper) 
        : base(repository, unitOfWork, mapper)
    {
    }
    
    public async Task<BookModel?> GetByIdAsync(Guid id)
    {
        var entity = await Repository.GetByIdAsync(id);
        
        if(entity is null)
            throw new EntityNotFoundException<Book>(id);
        
        return Mapper.Map<BookModel>(entity);
    }

    public async Task<IEnumerable<BookModel>> GetAllAsync()
    {
        var entities = await Repository.GetAllAsync();
        
        return Mapper.Map<IEnumerable<BookModel>>(entities);
    }

    public async Task AddAsync(BookModel model)
    {
        model.Id = Guid.NewGuid();
        
        await Repository.AddAsync(Mapper.Map<Book>(model));
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, BookModel model)
    {
        var entity = await Repository.GetByIdAsync(id);
        
        if(entity is null)
            throw new EntityNotFoundException<Book>(model.Id);
        
        Repository.Update(Mapper.Map(model, entity));
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await Repository.DeleteByIdAsync(id);
    }

    public async Task<IEnumerable<BookModel>> GetSearchResultsAsync(SearchQueryDto searchQuery, PaginationDto pagination)
    {
        var results = await ((IBookRepository)Repository).GetSearchResultsAsync(searchQuery, pagination);
        
        return Mapper.Map<IEnumerable<BookModel>>(results);
    }
}