namespace ConsumptionNotes.Domain.Models;

public class NaturalGasConsumption(
    DateOnly date,
    double cubicMeterConsumed,
    decimal amountToPay) : ConsumptionBase(date, amountToPay)
{
    public double CubicMeterConsumed { get; set; } = cubicMeterConsumed;
}