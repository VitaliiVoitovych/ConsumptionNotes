using ConsumptionNotes.Application.Services;
using ConsumptionNotes.Application.Services.Notes;

namespace ConsumptionNotes.Application.ViewModels.Adding;

public abstract partial class BaseNaturalGasAddingViewModel(NaturalGasNotesService notesService)
    : BaseAddingViewModel<NaturalGasConsumption, NaturalGasNotesService>(notesService)
{
    [ObservableProperty] private double _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.95689m;

    protected override NaturalGasConsumption CreateConsumption()
    {
        var amount = PaymentCalculator.CalculateNaturalGasPayment(CubicMeterConsumed, CubicMeterPrice);
        return new NaturalGasConsumption(
            SelectedDate,
            CubicMeterConsumed,
            amount);
    }
}