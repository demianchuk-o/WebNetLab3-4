using LibrarySystem.Bll.Models.Abstract;

namespace LibrarySystem.Bll.Models;

public class UserModel : IModel
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
}