using CommunityToolkit.Mvvm.ComponentModel;

namespace ConsumptionNotes.Domain.Models;

public partial class ElectricityConsumption(
    DateOnly date,
    int dayKilowattConsumed,
    int nightKilowattConsumed,
    decimal amountToPay)
    : BaseConsumption(date, amountToPay)
{
    //public int DayKilowattConsumed { get; set; } = dayKilowattConsumed;
    //public int NightKilowattConsumed { get; set; } = nightKilowattConsumed;

    [ObservableProperty] private int _dayKilowattConsumed = dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed = nightKilowattConsumed;
}