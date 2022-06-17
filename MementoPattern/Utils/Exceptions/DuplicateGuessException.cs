namespace MementoPattern.Utils.Exceptions;

public class DuplicateGuessException: Exception
{
    public DuplicateGuessException(string message) : base(message)
    {
    }
}