namespace ConsumptionNotes.Domain.Models;

public abstract record BaseConsumption(
    int Id, DateOnly Date, decimal AmountToPay);