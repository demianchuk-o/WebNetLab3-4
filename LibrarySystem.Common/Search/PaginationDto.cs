namespace LibrarySystem.Common.Search;

public record PaginationDto(
    int PageNumber = 0,
    int PageSize = 0
    );