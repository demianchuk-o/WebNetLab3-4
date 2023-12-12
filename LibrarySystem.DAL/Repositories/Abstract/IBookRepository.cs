using LibrarySystem.Common.Search;
using LibrarySystem.DAL.Entities;

namespace LibrarySystem.DAL.Repositories.Abstract;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetAllWithAuthorAndSubjectAsync();
    Task<Book?> GetByIdWithAuthorAndSubjectAsync(Guid id);
    Task<IEnumerable<Book>> GetSearchResultsAsync(SearchQueryDto searchQuery, PaginationDto pagination);
}