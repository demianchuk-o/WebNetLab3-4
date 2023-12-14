using LibrarySystem.Bll.Models;

namespace LibrarySystem.Bll.Services.Abstract;

public interface ILoanService : ICrudService<LoanModel>
{
    Task ReturnLoanAsync(Guid id);
}