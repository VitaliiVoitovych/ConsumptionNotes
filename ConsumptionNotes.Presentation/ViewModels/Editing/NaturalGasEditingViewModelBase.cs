namespace ConsumptionNotes.Presentation.ViewModels.Editing;

public partial class NaturalGasEditingViewModelBase(ObservableNaturalGasNotesService notesService) 
    : ConsumptionEditingViewModelBase<NaturalGasConsumption, ObservableNaturalGasConsumption, ObservableNaturalGasNotesService>(notesService)
{
    [ObservableProperty] private double _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.95689m;

    protected override void Update()
    {
        var amountToPay = PaymentCalculator.CalculateNaturalGasPayment(CubicMeterConsumed, CubicMeterPrice);
        
        Consumption.CubicMeterConsumed = CubicMeterConsumed;
        Consumption.AmountToPay = amountToPay;
        
        base.Update();
    }
}