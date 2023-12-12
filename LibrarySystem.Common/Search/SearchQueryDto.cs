namespace LibrarySystem.Common.Search;

public record SearchQueryDto(
    string? TitleKeyword,
    string? AuthorKeyword,
    string? SubjectKeyword
    );