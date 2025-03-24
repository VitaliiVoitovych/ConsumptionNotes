using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsumptionNotes.Domain.Models;

public abstract class ConsumptionBase(DateOnly date, decimal amountToPay)
{
    [Key, JsonIgnore]
    public int Id { get; init; }
    
    public  DateOnly Date { get; set; } = date;
    public decimal AmountToPay { get; set; } = amountToPay;
};