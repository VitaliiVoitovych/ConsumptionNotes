namespace ConsumptionNotes.Presentation.ViewModels.Editing;

public abstract partial class NaturalGasEditingViewModelBase(ObservableNaturalGasNotesService notesService) 
    : ConsumptionEditingViewModelBase<NaturalGasConsumption, ObservableNaturalGasConsumption>(notesService)
{
    [ObservableProperty] private double _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = ConsumptionTariffs.CubicMeterPrice;

    public override void SetConsumption(ObservableNaturalGasConsumption consumption)
    {
        Consumption = consumption;
        
        CubicMeterConsumed = Consumption.CubicMeterConsumed;
    }

    protected override void Update()
    {
        var amountToPay = PaymentCalculator.CalculateNaturalGasPayment(CubicMeterConsumed, CubicMeterPrice);
        
        Consumption.CubicMeterConsumed = CubicMeterConsumed;
        Consumption.AmountToPay = amountToPay;
        
        base.Update();
    }
}