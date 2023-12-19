using LibrarySystem.DAL.Entities.Abstract;

namespace LibrarySystem.DAL.Entities;

public class Book : IIdentity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    public bool Availability { get; set; } = true;
    
    public ICollection<Loan> Loans { get; init; } = new List<Loan>();
}