using LibrarySystem.Common.Search;
using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories.Abstract;
using LibrarySystem.DAL.Specifications.Books;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DAL.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Book>> GetAllWithAuthorAndSubjectAsync()
    {
        return await ApplySpecification(new AllBooksWithAuthorAndSubjectSpecification())
            .ToListAsync();
    }

    public async Task<Book?> GetByIdWithAuthorAndSubjectAsync(Guid id)
    {
        return await ApplySpecification(new BookByIdWithAuthorAndSubjectSpecification(id))
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Book>> GetSearchResultsAsync(SearchQueryDto searchQuery, PaginationDto pagination)
    {
        return await ApplySpecification(new BooksSearchQuerySpecification(searchQuery, pagination))
            .ToListAsync();
    }
}