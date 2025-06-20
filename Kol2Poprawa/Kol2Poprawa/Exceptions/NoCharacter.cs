namespace Kol2Poprawa.Exceptions;

public class NoCharacter:Exception
{
    public NoCharacter()
    {
    }

    public NoCharacter(string? message) : base(message)
    {
    }

    public NoCharacter(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}