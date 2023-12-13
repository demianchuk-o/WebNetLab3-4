namespace LibrarySystem.DAL.UnitOfWork.Abstract;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}