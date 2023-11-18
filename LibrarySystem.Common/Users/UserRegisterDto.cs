namespace LibrarySystem.Common.Users;

public record UserRegisterDto(
    string Email,
    string Username,
    string Password
    );