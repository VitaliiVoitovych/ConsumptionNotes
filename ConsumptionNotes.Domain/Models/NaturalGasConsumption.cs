namespace ConsumptionNotes.Domain.Models;

public record NaturalGasConsumption(
    DateOnly Date,
    int CubicMeterConsumed,
    decimal AmountToPay) : BaseConsumption(Date, AmountToPay);