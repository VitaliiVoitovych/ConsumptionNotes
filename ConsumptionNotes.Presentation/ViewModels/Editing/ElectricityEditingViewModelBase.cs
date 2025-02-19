namespace ConsumptionNotes.Presentation.ViewModels.Editing;

public abstract partial class ElectricityEditingViewModelBase(ObservableElectricityNotesService notesService) 
    : ConsumptionEditingViewModelBase<ElectricityConsumption, ObservableElectricityConsumption, ObservableElectricityNotesService>(notesService)
{
    [ObservableProperty] private int _dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;
    
    protected override void Update()
    {
        var amountToPay =
            PaymentCalculator.CalculateElectricityPayment(DayKilowattConsumed, NightKilowattConsumed,
                KilowattPerHourPrice);
        
        Consumption.DayKilowattConsumed = DayKilowattConsumed;
        Consumption.NightKilowattConsumed = NightKilowattConsumed;
        Consumption.AmountToPay = amountToPay;
        
        base.Update();
    }
}