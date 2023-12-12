using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Specifications.Abstract;

namespace LibrarySystem.DAL.Specifications.Loans;

internal class AllLoansWithUserAndBooksSpecification : Specification<Loan>
{
    public AllLoansWithUserAndBooksSpecification()
    : base(null)
    {
        AddInclude(loan => loan.Borrower);
        AddInclude(loan => loan.Books);
    }
}