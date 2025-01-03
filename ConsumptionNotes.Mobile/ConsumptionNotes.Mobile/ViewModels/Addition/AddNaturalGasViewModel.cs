using ConsumptionNotes.Mobile.ViewModels.Addition;

namespace ConsumptionNotes.Mobile.ViewModels.Addition;

public partial class AddNaturalGasViewModel(NaturalGasNotesService notesService) : BaseAddViewModel<NaturalGasConsumption, NaturalGasNotesService>(notesService)
{
    [ObservableProperty] private double _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.95689m;

    protected override decimal CalculateAmount()
    {
        return Convert.ToDecimal(CubicMeterConsumed) * CubicMeterPrice;
    }

    protected override NaturalGasConsumption CreateConsumption()
    {
        return new NaturalGasConsumption(
            SelectedDate,
            CubicMeterConsumed,
            CalculateAmount());
    }
}
