using CommunityToolkit.Mvvm.ComponentModel;

namespace ConsumptionNotes.Domain.Models;

public partial class NaturalGasConsumption(
    DateOnly date,
    double cubicMeterConsumed,
    decimal amountToPay) : BaseConsumption(date, amountToPay)
{
    //public double CubicMeterConsumed { get; set; } = cubicMeterConsumed;
    [ObservableProperty] private double _cubicMeterConsumed = cubicMeterConsumed;
}