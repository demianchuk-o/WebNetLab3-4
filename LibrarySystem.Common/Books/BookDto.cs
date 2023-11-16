namespace LibrarySystem.Common.Books;

public record BookDto(
    string Title,
    string Author,
    string Subject,
    bool Availability
    );