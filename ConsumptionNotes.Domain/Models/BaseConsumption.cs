using System.ComponentModel.DataAnnotations;

namespace ConsumptionNotes.Domain.Models;

public abstract record BaseConsumption(
    DateOnly Date,
    decimal AmountToPay)
{
    [Key]
    public int Id { get; init; }
};