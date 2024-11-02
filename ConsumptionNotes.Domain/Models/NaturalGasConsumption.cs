namespace ConsumptionNotes.Domain.Models;

public record NaturalGasConsumption(
    DateOnly Date,
    double CubicMeterConsumed,
    decimal AmountToPay) : BaseConsumption(Date, AmountToPay);