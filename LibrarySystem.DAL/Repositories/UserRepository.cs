using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DAL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Context.Set<User>()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<string> GetRoleNameAsync(User user)
    {
        var userRole = await Context.Set<IdentityUserRole<Guid>>()
            .FirstOrDefaultAsync(i => i.UserId == user.Id);
        
        return await Context.Set<LibraryRole>()
            .Where(r => r.Id == userRole.RoleId)
            .Select(r => r.Name)
            .FirstOrDefaultAsync();
    }
}