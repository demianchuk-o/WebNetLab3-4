using LibrarySystem.DAL.Entities;

namespace LibrarySystem.DAL.Repositories.Abstract;

public interface ISubjectRepository : IRepository<Subject>
{
    Task<Subject?> GetByNameAsync(string name);
}