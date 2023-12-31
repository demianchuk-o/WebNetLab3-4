﻿using LibrarySystem.DAL.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace LibrarySystem.DAL.Entities;

public class User : IdentityUser<Guid>, IIdentity
{
    public ICollection<Loan> Loans { get; init; } = new List<Loan>();
}