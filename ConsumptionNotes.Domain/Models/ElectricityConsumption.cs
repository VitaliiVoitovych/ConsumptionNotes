namespace ConsumptionNotes.Domain.Models;

public record ElectricityConsumption(
    int Id, 
    DateOnly Date,
    int DayKilowattConsumed,
    int NightKilowattConsumed,
    decimal AmountToPay) : BaseConsumption(Id, Date, AmountToPay);