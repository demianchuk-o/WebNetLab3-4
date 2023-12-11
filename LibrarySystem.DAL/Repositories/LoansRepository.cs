using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories.Abstract;
using LibrarySystem.DAL.Specifications.Loans;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DAL.Repositories;

public class LoansRepository : Repository<Loan>, ILoanRepository
{
    public LoansRepository(DbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Loan>> GetAllWithUserAndBooksAsync()
    {
        return await ApplySpecification(new AllLoansWithUserAndBooksSpecification())
            .ToListAsync();
    }

    public async Task<Loan?> GetByIdWithUserAndBooksAsync(Guid id)
    {
        return await ApplySpecification(new LoanByIdWIthUserAndBooksSpecification(id))
            .FirstOrDefaultAsync();
    }
}