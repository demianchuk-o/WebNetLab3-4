using LibrarySystem.DAL.Entities;

namespace LibrarySystem.DAL.Repositories.Abstract;

public interface ILoanRepository : IRepository<Loan> 
{
    Task<IEnumerable<Loan>> GetAllWithUserAndBooksAsync();
    Task<Loan?> GetByIdWithUserAndBooksAsync(Guid id);
}