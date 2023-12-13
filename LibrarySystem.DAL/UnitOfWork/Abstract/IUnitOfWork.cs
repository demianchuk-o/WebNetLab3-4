using LibrarySystem.DAL.Repositories.Abstract;

namespace LibrarySystem.DAL.UnitOfWork.Abstract;

public interface IUnitOfWork
{
    IBookRepository Books { get; }
    IAuthorRepository Authors { get; }
    ISubjectRepository Subjects { get; }
    ILoanRepository Loans { get; }
    IUserRepository Users { get; }
    
    Task<int> SaveChangesAsync();
}