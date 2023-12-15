using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DAL.Repositories;

public class SubjectRepository : Repository<Subject>, ISubjectRepository
{
    public SubjectRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<Subject?> GetByNameAsync(string name)
    {
        return await Context.Set<Subject>()
            .FirstOrDefaultAsync(s => s.Name == name);
    }
}