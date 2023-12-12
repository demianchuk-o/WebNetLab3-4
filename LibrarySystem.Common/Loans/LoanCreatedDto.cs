using LibrarySystem.Common.Books;
using LibrarySystem.Common.Users;

namespace LibrarySystem.Common.Loans;

public record LoanCreatedDto(
    UserDto Borrower,
    ICollection<BookDto> Books
    );