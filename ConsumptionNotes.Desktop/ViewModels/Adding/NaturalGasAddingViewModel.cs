namespace ConsumptionNotes.Desktop.ViewModels.Adding;

public partial class NaturalGasAddingViewModel(NaturalGasNotesService notesService)
    : BaseAddingViewModel<NaturalGasConsumption, NaturalGasNotesService>(notesService)
{
    [ObservableProperty] private double _cubicMetersConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.95689m;

    protected override decimal CalculateAmount()
    {
        return Convert.ToDecimal(CubicMetersConsumed) * CubicMeterPrice;
    }

    protected override NaturalGasConsumption CreateConsumption()
    {
        return new NaturalGasConsumption(
            DateOnly.FromDateTime(SelectedDate.DateTime),
            CubicMetersConsumed,
            CalculateAmount());
    }
}