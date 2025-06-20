namespace Kol2Poprawa.Exceptions;

public class NoItem : Exception
{
    public NoItem()
    {
    }

    public NoItem(string? message) : base(message)
    {
    }

    public NoItem(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}