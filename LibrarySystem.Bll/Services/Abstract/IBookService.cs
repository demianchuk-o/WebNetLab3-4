using LibrarySystem.Bll.Models;
using LibrarySystem.Common.Search;

namespace LibrarySystem.Bll.Services.Abstract;

public interface IBookService : ICrudService<BookModel>
{
    Task<IEnumerable<BookModel>> GetSearchResultsAsync(SearchQueryDto searchQuery, PaginationDto pagination);
}