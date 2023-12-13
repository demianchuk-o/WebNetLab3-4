using LibrarySystem.Bll.Models;

namespace LibrarySystem.Bll.Services.Abstract;

public interface IUserService : ICrudService<UserModel>
{
    Task<UserModel?> GetByEmailAsync(string email);
    Task<string> AuthenticateAsync(string email, string password);
    Task RegisterAsync(UserModel model, string password);
}