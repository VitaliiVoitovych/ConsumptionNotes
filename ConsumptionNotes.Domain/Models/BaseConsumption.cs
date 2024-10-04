using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsumptionNotes.Domain.Models;

public abstract record BaseConsumption(
    DateOnly Date,
    decimal AmountToPay)
{
    [Key, JsonIgnore]
    public int Id { get; init; }
};