using ConsumptionNotes.Application.Services;
using ConsumptionNotes.Application.ViewModels;

namespace ConsumptionNotes.Desktop.ViewModels.Editing;

public partial class ElectricityEditingViewModel(ElectricityNotesService notesService) : ViewModelBase
{
    public ElectricityConsumption Consumption { get; private set; }
    
    [ObservableProperty] private int _dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;

    public void SetConsumption(ElectricityConsumption consumption)
    {
        Consumption = consumption;

        DayKilowattConsumed = Consumption.DayKilowattConsumed;
        NightKilowattConsumed = Consumption.NightKilowattConsumed;
    }
    
    [RelayCommand]
    private void Update()
    {
        var amountToPay =
            PaymentCalculator.CalculateElectricityPayment(DayKilowattConsumed, NightKilowattConsumed,
                KilowattPerHourPrice);
        
        Consumption.DayKilowattConsumed = DayKilowattConsumed;
        Consumption.NightKilowattConsumed = NightKilowattConsumed;
        Consumption.AmountToPay = amountToPay;
        
        notesService.UpdateNote(Consumption);
    }
}