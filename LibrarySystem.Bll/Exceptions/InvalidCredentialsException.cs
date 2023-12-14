namespace LibrarySystem.Bll.Exceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException(string email) : base($"Invalid credentials for user with email: {email}")
    {
    }
}