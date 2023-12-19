using System.Linq.Expressions;
using LibrarySystem.Common.Search;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Specifications.Abstract;

namespace LibrarySystem.DAL.Specifications.Books;

public class BooksSearchQuerySpecification : Specification<Book>
{
    public BooksSearchQuerySpecification(SearchQueryDto searchQuery, PaginationDto pagination) 
        : base(BuildCriteria(searchQuery))
    {
        AddInclude(book => book.Author);
        AddInclude(book => book.Subject);
        var (skip, take) = PaginationHelper.GetPaginationValues(pagination.PageNumber, pagination.PageSize);
        AddPaging(skip, take);
    }

    private static Expression<Func<Book, bool>> BuildCriteria(SearchQueryDto searchQuery)
    {
        var criteria = PredicateBuilder.True<Book>();
        
        if (!string.IsNullOrWhiteSpace(searchQuery.TitleKeyword))
        {
            criteria = criteria.And(b => b.Title.Contains(searchQuery.TitleKeyword));
        }
        if(!string.IsNullOrWhiteSpace(searchQuery.AuthorKeyword))
        {
            criteria = criteria.And(b => b.Author.Name.Contains(searchQuery.AuthorKeyword));
        }
        if(!string.IsNullOrWhiteSpace(searchQuery.SubjectKeyword))
        {
            criteria = criteria.And(b => b.Subject.Name.Contains(searchQuery.SubjectKeyword));
        }
        
        return criteria;
    }
}