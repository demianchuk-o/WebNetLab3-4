﻿using AutoMapper;
using LibrarySystem.Bll.Exceptions;
using LibrarySystem.Bll.Models;
using LibrarySystem.Bll.Services.Abstract;
using LibrarySystem.Common.Search;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories.Abstract;
using LibrarySystem.DAL.UnitOfWork.Abstract;

namespace LibrarySystem.Bll.Services;

public class BookService : BaseService<Book>, IBookService
{
    public BookService(IUnitOfWork unitOfWork, IMapper mapper) 
        : base(unitOfWork, mapper)
    {
    }
    
    public async Task<BookModel?> GetByIdAsync(Guid id)
    {
        var entity = await UnitOfWork.Books.GetByIdAsync(id);
        
        if(entity is null)
            throw new EntityNotFoundException<Book>(id);
        
        return Mapper.Map<BookModel>(entity);
    }

    public async Task<IEnumerable<BookModel>> GetAllAsync()
    {
        var entities = await UnitOfWork.Books.GetAllAsync();
        
        return Mapper.Map<IEnumerable<BookModel>>(entities);
    }

    public async Task AddAsync(BookModel model)
    {
        model.Id = Guid.NewGuid();
        
        await UnitOfWork.Books.AddAsync(Mapper.Map<Book>(model));
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, BookModel model)
    {
        var entity = await UnitOfWork.Books.GetByIdAsync(id);
        
        if(entity is null)
            throw new EntityNotFoundException<Book>(model.Id);
        
        UnitOfWork.Books.Update(Mapper.Map(model, entity));
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await UnitOfWork.Books.DeleteByIdAsync(id);
    }

    public async Task<IEnumerable<BookModel>> GetSearchResultsAsync(SearchQueryDto searchQuery, PaginationDto pagination)
    {
        var results = await UnitOfWork.Books.GetSearchResultsAsync(searchQuery, pagination);
        
        return Mapper.Map<IEnumerable<BookModel>>(results);
    }
}