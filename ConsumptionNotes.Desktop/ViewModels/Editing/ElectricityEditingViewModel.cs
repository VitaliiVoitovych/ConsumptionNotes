using ConsumptionNotes.Application.Services;
using ConsumptionNotes.Application.Models;

namespace ConsumptionNotes.Desktop.ViewModels.Editing;

public partial class ElectricityEditingViewModel(ElectricityNotesService notesService) 
    : BaseEditingViewModel<ElectricityConsumption, ObservableElectricityConsumption>
{
    
    [ObservableProperty] private int _dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;

    public override void SetConsumption(ObservableElectricityConsumption consumption)
    {
        base.SetConsumption(consumption);

        DayKilowattConsumed = Consumption.DayKilowattConsumed;
        NightKilowattConsumed = Consumption.NightKilowattConsumed;
    }
    
    protected override void Update()
    {
        var amountToPay =
            PaymentCalculator.CalculateElectricityPayment(DayKilowattConsumed, NightKilowattConsumed,
                KilowattPerHourPrice);
        
        Consumption.DayKilowattConsumed = DayKilowattConsumed;
        Consumption.NightKilowattConsumed = NightKilowattConsumed;
        Consumption.AmountToPay = amountToPay;
        
        notesService.UpdateNote(Consumption.Consumption);
    }
}