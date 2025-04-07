namespace ConsumptionNotes.Presentation.ViewModels.Adding;

public abstract partial class NaturalGasAddingViewModelBase(ObservableNaturalGasNotesService notesService) 
    : ConsumptionAddingViewModelBase<NaturalGasConsumption, ObservableNaturalGasConsumption>(notesService)
{
    [ObservableProperty] private double _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = ConsumptionTariffs.CubicMeterPrice;

    protected override ObservableNaturalGasConsumption CreateConsumption()
    {
        var amount = PaymentCalculator.CalculateNaturalGasPayment(CubicMeterConsumed, CubicMeterPrice);
        var consumption = new NaturalGasConsumption(
            SelectedDate,
            CubicMeterConsumed,
            amount);

        return new ObservableNaturalGasConsumption(consumption);
    }
}