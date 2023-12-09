using LibrarySystem.DAL.Entities.Abstract;

namespace LibrarySystem.DAL.Entities;

public class Loan : IIdentity
{
    public Guid Id { get; set; }
    public Guid BorrowerId { get; set; }
    public User Borrower { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; } = null;
    
    public ICollection<Book> Books { get; init; } = new List<Book>();
}