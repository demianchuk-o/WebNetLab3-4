using LibrarySystem.DAL.Entities.Abstract;

namespace LibrarySystem.DAL.Entities;

public class Author : IIdentity
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public ICollection<Book> Books { get; init; } = new List<Book>();
}