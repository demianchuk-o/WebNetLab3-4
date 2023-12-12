using LibrarySystem.Bll.Models;

namespace LibrarySystem.Bll.Services.Abstract;

public interface ILoanService : ICrudService<LoanModel>
{
    Task MakeLoanAsync(LoanModel model);
    Task ReturnLoanAsync(Guid id);
}