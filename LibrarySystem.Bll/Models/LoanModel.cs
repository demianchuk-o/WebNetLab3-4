using LibrarySystem.Bll.Models.Abstract;

namespace LibrarySystem.Bll.Models;

public class LoanModel : IModel
{
    public Guid Id { get; init; }
    public UserModel Borrower { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; } = null;
    
    public ICollection<BookModel> Books { get; init; } = new List<BookModel>();
}