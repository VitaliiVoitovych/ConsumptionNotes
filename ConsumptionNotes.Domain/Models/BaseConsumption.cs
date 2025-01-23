using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ConsumptionNotes.Domain.Models;

public abstract partial class BaseConsumption(DateOnly date, decimal amountToPay) : ObservableObject
{
    [Key, JsonIgnore]
    public int Id { get; init; }
    
    public  DateOnly Date { get; set; } = date;
    //public decimal AmountToPay { get; set; } = amountToPay;
    [ObservableProperty] private decimal _amountToPay = amountToPay;
};