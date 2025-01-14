using ConsumptionNotes.Application.Services;
using ConsumptionNotes.Application.Services.Notes;

namespace ConsumptionNotes.Application.ViewModels.Adding;

public abstract partial class BaseElectricityAddingViewModel(ElectricityNotesService notesService) 
    : BaseAddingViewModel<ElectricityConsumption, ElectricityNotesService>(notesService)
{
    [ObservableProperty] private int _dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;
    
    protected override ElectricityConsumption CreateConsumption()
    {
        var amount = PaymentCalculator.CalculateElectricityPayment(DayKilowattConsumed, NightKilowattConsumed, KilowattPerHourPrice);
        return new ElectricityConsumption(
            SelectedDate,
            DayKilowattConsumed,
            NightKilowattConsumed,
            amount);
    }
}