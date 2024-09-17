namespace ConsumptionNotes.Domain.Models;

public abstract record BaseConsumption(
    DateOnly Date,
    decimal AmountToPay)
{
    private int Id { get; init; }
};