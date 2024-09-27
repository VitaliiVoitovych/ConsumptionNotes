namespace ConsumptionNotes.ViewModels.Addition;

public partial class NaturalGasNoteViewModel
    : ConsumptionNoteViewModelBase<NaturalGasConsumption, NaturalGasNotesService>
{
    [ObservableProperty] private int _cubicMetersConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.99m;

    public NaturalGasNoteViewModel(NaturalGasNotesService notesService)
        : base(notesService)
    {
        
    }
    
    protected override decimal CalculateAmount()
    {
        return CubicMetersConsumed * CubicMeterPrice;
    }

    protected override NaturalGasConsumption CreateConsumption()
    {
        return new NaturalGasConsumption(
            DateOnly.FromDateTime(SelectedDate.DateTime),
            CubicMetersConsumed,
            CalculateAmount());
    }
}