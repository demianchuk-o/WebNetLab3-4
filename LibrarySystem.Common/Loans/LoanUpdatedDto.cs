using LibrarySystem.Common.Books;
using LibrarySystem.Common.Users;

namespace LibrarySystem.Common.Loans;

public record LoanUpdatedDto(
    UserDto Borrower,
    ICollection<BookDto> Books,
    DateTime DateBorrowed,
    DateTime DueDate,
    DateTime ReturnDate
    );