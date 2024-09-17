namespace ConsumptionNotes.Domain.Models;

public record NaturalGasConsumption(
    int Id,
    DateOnly Date,
    int CubicMeterConsumed,
    decimal AmountToPay) : BaseConsumption(Id, Date, AmountToPay);