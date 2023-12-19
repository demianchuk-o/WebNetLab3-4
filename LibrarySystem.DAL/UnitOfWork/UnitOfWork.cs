using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Repositories.Abstract;
using LibrarySystem.DAL.UnitOfWork.Abstract;

namespace LibrarySystem.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _context;

    public IBookRepository Books { get; }
    public IAuthorRepository Authors { get; }
    public ISubjectRepository Subjects { get; }
    public ILoanRepository Loans { get; }
    public IUserRepository Users { get; }
    public UnitOfWork(LibraryDbContext context, IBookRepository books, IAuthorRepository authors, ISubjectRepository subjects, ILoanRepository loans, IUserRepository users)
    {
        _context = context;
        Books = books;
        Authors = authors;
        Subjects = subjects;
        Loans = loans;
        Users = users;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}