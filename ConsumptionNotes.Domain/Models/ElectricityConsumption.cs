namespace ConsumptionNotes.Domain.Models;

public record ElectricityConsumption(
    DateOnly Date,
    int DayKilowattConsumed,
    int NightKilowattConsumed,
    decimal AmountToPay) : BaseConsumption(Date, AmountToPay);