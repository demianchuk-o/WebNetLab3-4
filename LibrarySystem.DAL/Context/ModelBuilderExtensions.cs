using LibrarySystem.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace LibrarySystem.DAL.Context;

public static class ModelBuilderExtensions
{
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Borrower)
            .WithMany(u => u.Loans)
            .HasForeignKey(l => l.BorrowerId);

        modelBuilder.Entity<Loan>()
            .HasMany(l => l.Books)
            .WithMany(b => b.Loans);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Subject)
            .WithMany(s => s.Books)
            .HasForeignKey(b => b.SubjectId);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);
    }

    private const int Seed = 100;

    public static void SeedData(this ModelBuilder modelBuilder)
    {
        var randomizer = new Randomizer(Seed);

        var roles = modelBuilder.SeedRoles();

        var staffUsers = modelBuilder.SeedStaffUsers();
        var staffRoles = roles.Where(r => r.Name != "Reader").ToList();
        modelBuilder.AssignRoles(staffUsers, staffRoles);

        var readerUsers = modelBuilder.SeedReaderUsers();
        var readerRole = roles.Single(r => r.Name == "Reader");
        modelBuilder.AssignRoles(readerUsers, new() { readerRole });

        var authors = modelBuilder.SeedAuthors();
        var subjects = modelBuilder.SeedSubjects();

        modelBuilder.SeedBooks(authors, subjects);
    }


    private static List<LibraryRole> SeedRoles(this ModelBuilder modelBuilder)
    {
        var roles = GetRoles();

        modelBuilder.Entity<LibraryRole>().HasData(roles);

        return roles;
    }

    private static List<User> SeedStaffUsers(this ModelBuilder modelBuilder)
    {
        var staffUsers = GetStaffUsers(new PasswordHasher<User>());

        modelBuilder.Entity<User>().HasData(staffUsers);

        return staffUsers;
    }

    private static List<User> SeedReaderUsers(this ModelBuilder modelBuilder)
    {
        var readerUsers = GetReaderUsers(new PasswordHasher<User>());

        modelBuilder.Entity<User>().HasData(readerUsers);

        return readerUsers;
    }

    private static List<LibraryRole> GetRoles()
    {
        return new()
        {
            new LibraryRole
            {
                Id = Guid.NewGuid(),
                Name = "Admin"
            },
            new LibraryRole
            {
                Id = Guid.NewGuid(),
                Name = "CatalogManager"
            },
            new LibraryRole
            {
                Id = Guid.NewGuid(),
                Name = "LoansManager"
            },
            new LibraryRole
            {
                Id = Guid.NewGuid(),
                Name = "Reader"
            }
        };
    }

    private static List<User> GetStaffUsers(PasswordHasher<User> passwordHasher)
    {
        return new()
        {
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Email = "admin@mail.com",
                PasswordHash = passwordHasher.HashPassword(null, "admin")
            },

            new User
            {
                Id = Guid.NewGuid(),
                UserName = "catalogManager",
                Email = "catalogManager@mail.com",
                PasswordHash = passwordHasher.HashPassword(null, "catalogManager")
            },

            new User
            {
                Id = Guid.NewGuid(),
                UserName = "loansManager",
                Email = "loansManager@mail.com",
                PasswordHash = passwordHasher.HashPassword(null, "loansManager")
            }
        };
    }

    private static List<User> GetReaderUsers(PasswordHasher<User> passwordHasher)
    {
        var readers = Enumerable.Range(1, EntitiesCount)
            .Select(i => new User
            {
                Id = Guid.NewGuid(),
                UserName = $"reader{i}",
                Email = $"reader{i}@mail.com",
                PasswordHash = passwordHasher.HashPassword(null, $"reader{i}")

            })
            .ToList();

        return readers;
    }

    private static void AssignRoles(this ModelBuilder modelBuilder, List<User> users, List<LibraryRole> roles)
    {
        var userRoles = users.Select((u, i) => new IdentityUserRole<Guid>
            {
                UserId = u.Id,
                RoleId = roles[i % roles.Count].Id
            })
            .ToList();

        modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(userRoles);
    }

    private static List<Author> SeedAuthors(this ModelBuilder modelBuilder)
    {
        var authors = GetAuthors();

        modelBuilder.Entity<Author>().HasData(authors);

        return authors;
    }

    private static List<Subject> SeedSubjects(this ModelBuilder modelBuilder)
    {
        var subjects = GetSubjects();

        modelBuilder.Entity<Subject>().HasData(subjects);

        return subjects;
    }

    private const int EntitiesCount = 10;

    private static List<Author> GetAuthors()
    {
        var faker = new Faker<Author>();

        faker.RuleFor(a => a.Id, f => Guid.NewGuid())
            .RuleFor(a => a.Name, f => f.Person.FullName);

        return faker.Generate(EntitiesCount);
    }

    private static List<Subject> GetSubjects()
    {
        var faker = new Faker<Subject>();

        faker.RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.Name, f => f.Lorem.Word());

        return faker.Generate(EntitiesCount);
    }

    private static void SeedBooks(this ModelBuilder modelBuilder, List<Author> authors, List<Subject> subjects)
    {
        var books = GetBooks(authors, subjects);

        modelBuilder.Entity<Book>().HasData(books);
    }

    private static List<Book> GetBooks(List<Author> authors, List<Subject> subjects)
    {
        var faker = new Faker<Book>();

        faker.RuleFor(b => b.Id, f => Guid.NewGuid())
            .RuleFor(b => b.Title, f => f.Lorem.Sentence())
            .RuleFor(b => b.AuthorId, f => f.PickRandom(authors).Id)
            .RuleFor(b => b.SubjectId, f => f.PickRandom(subjects).Id)
            .RuleFor(b => b.Availability, f => true);

        return faker.Generate(2 * EntitiesCount * EntitiesCount);
    }
}