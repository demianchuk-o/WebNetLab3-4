namespace LibrarySystem.Common.Search;

public record SearchQueryDto(
    string? TitleKeyword = null,
    string? AuthorKeyword = null,
    string? SubjectKeyword = null
    );