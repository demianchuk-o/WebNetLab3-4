using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.UnitOfWork.Abstract;

namespace LibrarySystem.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _context;

    public UnitOfWork(LibraryDbContext context)
    {
        _context = context;
    }


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}