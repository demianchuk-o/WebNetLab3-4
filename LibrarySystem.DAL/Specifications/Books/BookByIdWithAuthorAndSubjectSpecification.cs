using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Specifications.Abstract;

namespace LibrarySystem.DAL.Specifications.Books;

public class BookByIdWithAuthorAndSubjectSpecification : Specification<Book>
{
    public BookByIdWithAuthorAndSubjectSpecification(Guid id) 
        : base(b => b.Id == id)
    {
        AddInclude(book => book.Author);
        AddInclude(book => book.Subject);
    }
}