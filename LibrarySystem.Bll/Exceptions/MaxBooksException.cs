namespace LibrarySystem.Bll.Exceptions;

public class MaxBooksException : Exception
{
    public MaxBooksException(int booksCount) : base($"No more than {booksCount} books are allowed to take")
    {
    }
}