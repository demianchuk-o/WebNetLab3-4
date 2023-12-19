namespace LibrarySystem.Bll.Exceptions;

public class BookNotAvailableException : Exception
{
    public BookNotAvailableException(Guid id) : base($"Book with id {id} is not available.")
    {
    }
}