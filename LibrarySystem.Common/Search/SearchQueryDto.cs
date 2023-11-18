namespace LibrarySystem.Common.Search;

public record SearchQueryDto(
    string? NameKeyword,
    string? AuthorKeyword,
    string? SubjectKeyword
    );