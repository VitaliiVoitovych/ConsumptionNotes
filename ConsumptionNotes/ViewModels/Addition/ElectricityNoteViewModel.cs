namespace ConsumptionNotes.ViewModels.Addition;

public partial class ElectricityNoteViewModel
    : ConsumptionNoteViewModelBase<ElectricityConsumption, ElectricityNotesService>
{
    [ObservableProperty] private int _dayKilowattsConsumed;
    [ObservableProperty] private int _nightKilowattsConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;

    public ElectricityNoteViewModel(ElectricityNotesService notesService)
        : base(notesService)
    {
        
    }
    
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