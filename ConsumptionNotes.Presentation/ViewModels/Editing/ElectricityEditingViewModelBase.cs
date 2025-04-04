namespace ConsumptionNotes.Presentation.ViewModels.Editing;

public abstract partial class ElectricityEditingViewModelBase(ObservableElectricityNotesService notesService) 
    : ConsumptionEditingViewModelBase<ElectricityConsumption, ObservableElectricityConsumption>(notesService)
{
    [ObservableProperty] private int _dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;

    public override void SetConsumption(ObservableElectricityConsumption consumption)
    {
        Consumption = consumption;

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
        
        base.Update();
    }
}