using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Specifications.Abstract;

namespace LibrarySystem.DAL.Specifications.Loans;

internal class LoanByIdWIthUserAndBooksSpecification : Specification<Loan>
{
    public LoanByIdWIthUserAndBooksSpecification(Guid id)
    : base(loan => loan.Id == id)
    {
        AddInclude(loan => loan.Borrower);
        AddInclude(loan => loan.Books);
    }
}