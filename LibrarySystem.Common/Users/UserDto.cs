namespace LibrarySystem.Common.Users;

public record UserDto(
    Guid Id,
    string Email,
    string Username
    );