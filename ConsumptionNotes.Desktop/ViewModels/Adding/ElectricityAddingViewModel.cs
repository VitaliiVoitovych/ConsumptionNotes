namespace ConsumptionNotes.Desktop.ViewModels.Adding;

public partial class ElectricityAddingViewModel(ElectricityNotesService notesService)
    : BaseAddingViewModel<ElectricityConsumption, ElectricityNotesService>(notesService)
{
    [ObservableProperty] private int _dayKilowattsConsumed;
    [ObservableProperty] private int _nightKilowattsConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;

    protected override decimal CalculateAmount()
    {
        return DayKilowattsConsumed * KilowattPerHourPrice +
               NightKilowattsConsumed * (KilowattPerHourPrice * 0.5m);
    }

    protected override ElectricityConsumption CreateConsumption()
    {
        return new ElectricityConsumption(
            DateOnly.FromDateTime(SelectedDate.DateTime),
            DayKilowattsConsumed,
            NightKilowattsConsumed,
            CalculateAmount());
    }
}