namespace LibrarySystem.Common.Books;

public record BookUpdatedDto(
    string Title,
    string Author,
    string Subject,
    bool Availability
);
