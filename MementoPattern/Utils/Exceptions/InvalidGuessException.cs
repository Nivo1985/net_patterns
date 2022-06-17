namespace MementoPattern.Utils.Exceptions;

public class InvalidGuessException : Exception
{
    public InvalidGuessException(string message) : base(message)
    {
    }
}