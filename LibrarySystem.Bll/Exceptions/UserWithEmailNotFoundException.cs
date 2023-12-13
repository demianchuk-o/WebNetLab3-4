namespace LibrarySystem.Bll.Exceptions;

public class UserWithEmailNotFoundException : Exception
{
    public UserWithEmailNotFoundException(string email) : base($"User with email {email} was not found.")
    {
    }
}