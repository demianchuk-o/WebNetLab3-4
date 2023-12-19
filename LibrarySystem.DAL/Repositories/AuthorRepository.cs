using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DAL.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<Author?> GetByFullnameAsync(string fullname)
    {
        return await Context.Set<Author>()
            .FirstOrDefaultAsync(a => a.Name == fullname);
    }
}