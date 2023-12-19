using LibrarySystem.DAL.Entities.Abstract;

namespace LibrarySystem.DAL.Entities;

public class Subject : IIdentity
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public ICollection<Book> Books { get; init; } = new List<Book>();
}