namespace ConsumptionNotes.Domain.Exceptions;

public class FolderNotSelectedException : Exception
{
    public FolderNotSelectedException() { }

    public FolderNotSelectedException(string message) : base(message) { }

    public FolderNotSelectedException(string message, Exception innerException)
        : base(message, innerException) { }
}
