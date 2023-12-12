using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Specifications.Abstract;

namespace LibrarySystem.DAL.Specifications.Books;

public class AllBooksWithAuthorAndSubjectSpecification : Specification<Book>
{
    public AllBooksWithAuthorAndSubjectSpecification() 
        : base(null)
    {
        AddInclude(book => book.Author);
        AddInclude(book => book.Subject);
    }
}