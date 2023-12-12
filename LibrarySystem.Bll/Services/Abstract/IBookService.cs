using LibrarySystem.Bll.Models;

namespace LibrarySystem.Bll.Services.Abstract;

public interface IBookService : ICrudService<BookModel>
{
    Task<IEnumerable<BookModel>> GetSearchResultsAsync();
}