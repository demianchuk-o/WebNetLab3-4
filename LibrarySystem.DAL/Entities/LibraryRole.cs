using LibrarySystem.DAL.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace LibrarySystem.DAL.Entities;

public class LibraryRole : IdentityRole<Guid>, IIdentity
{
    
}