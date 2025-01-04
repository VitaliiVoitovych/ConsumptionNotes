namespace ConsumptionNotes.Domain.Exceptions;

public class FileNotSelectedException : Exception
{
    public FileNotSelectedException() { }

    public FileNotSelectedException(string message) : base(message) { }

    public FileNotSelectedException(string message, Exception innerException)
        : base(message, innerException) { }
}
