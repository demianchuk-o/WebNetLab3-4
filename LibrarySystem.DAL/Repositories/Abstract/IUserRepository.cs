using LibrarySystem.DAL.Entities;

namespace LibrarySystem.DAL.Repositories.Abstract;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<string> GetRoleNameAsync(User user); 
}