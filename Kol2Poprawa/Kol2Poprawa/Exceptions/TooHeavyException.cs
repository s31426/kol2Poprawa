namespace Kol2Poprawa.Exceptions;

public class TooHeavyException : Exception
{
    public TooHeavyException()
    {
    }

    public TooHeavyException(string? message) : base(message)
    {
    }

    public TooHeavyException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}