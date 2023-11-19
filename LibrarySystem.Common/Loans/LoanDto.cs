using LibrarySystem.Common.Books;
using LibrarySystem.Common.Users;

namespace LibrarySystem.Common.Loans;

public record LoanDto(
    Guid Id,
    UserDto Borrower,
    ICollection<BookDto> Books,
    DateTime DateBorrowed,
    DateTime DueDate,
    DateTime? ReturnDate
);