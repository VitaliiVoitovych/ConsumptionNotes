namespace ConsumptionNotes.Mobile.ViewModels.Adding;

public partial class AddElectricityViewModel(ElectricityNotesService notesService) 
    : BaseAddViewModel<ElectricityConsumption, ElectricityNotesService>(notesService)
{
    [ObservableProperty] private int _dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;

    protected override decimal CalculateAmount()
    {
        return DayKilowattConsumed * KilowattPerHourPrice +
               NightKilowattConsumed * (KilowattPerHourPrice * 0.5m);
    }

    protected override ElectricityConsumption CreateConsumption()
    {
        return new ElectricityConsumption(
            SelectedDate,
            DayKilowattConsumed,
            NightKilowattConsumed,
            CalculateAmount());
    }
}
