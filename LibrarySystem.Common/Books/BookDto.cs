namespace LibrarySystem.Common.Books;

public record BookDto(
    Guid Id,
    string Title,
    string Author,
    string Subject,
    bool Availability
    );