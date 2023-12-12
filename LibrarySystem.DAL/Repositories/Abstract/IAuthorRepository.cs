using LibrarySystem.DAL.Entities;

namespace LibrarySystem.DAL.Repositories.Abstract;

public interface IAuthorRepository : IRepository<Author>
{
    Task<Author?> GetByFullnameAsync(string fullname);
}