using ConsumptionNotes.Domain.Models;

namespace ConsumptionNotes.Domain.Exceptions;

public class InvalidConsumptionDataException : Exception
{
    public InvalidConsumptionDataException() { }
    
    public InvalidConsumptionDataException(string message) : base(message) { }
    
    public InvalidConsumptionDataException(string message, Exception innerException)
        : base(message, innerException) {}

    public static void ThrowIfDateInvalid<TConsumption>(TConsumption consumption)
        where TConsumption : ConsumptionBase
    {
        if (consumption.Date >= DateOnly.FromDateTime(DateTime.Now))
            throw new InvalidConsumptionDataException("Cannot add for the current or future month");
    }
}