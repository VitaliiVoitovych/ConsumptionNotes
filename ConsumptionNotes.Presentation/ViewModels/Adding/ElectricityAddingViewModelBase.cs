namespace ConsumptionNotes.Presentation.ViewModels.Adding;

public abstract partial class ElectricityAddingViewModelBase(ObservableElectricityNotesService notesService) 
    : ConsumptionAddingViewModelBase<ElectricityConsumption, ObservableElectricityConsumption>(notesService)
{
    [ObservableProperty] private int _dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;

    protected override ObservableElectricityConsumption CreateConsumption()
    {
        var amount = PaymentCalculator.CalculateElectricityPayment(DayKilowattConsumed, NightKilowattConsumed, KilowattPerHourPrice);
        var consumption = new ElectricityConsumption(
            SelectedDate,
            DayKilowattConsumed,
            NightKilowattConsumed,
            amount);

        return new ObservableElectricityConsumption(consumption);
    }
}