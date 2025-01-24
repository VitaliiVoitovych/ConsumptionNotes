using ConsumptionNotes.Application.Models;
using ConsumptionNotes.Application.Services;

namespace ConsumptionNotes.Desktop.ViewModels.Editing;

public partial class NaturalGasEditingViewModel(NaturalGasNotesService notesService) 
    : BaseEditingViewModel<NaturalGasConsumption, ObservableNaturalGasConsumption>
{
    
    [ObservableProperty] private double _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.95689m;
    
    public override void SetConsumption(ObservableNaturalGasConsumption consumption)
    {
        base.SetConsumption(consumption);

        CubicMeterConsumed = Consumption.CubicMeterConsumed;
    }
    
    protected override void Update()
    {
        var amountToPay = PaymentCalculator.CalculateNaturalGasPayment(CubicMeterConsumed, CubicMeterPrice);
        
        Consumption.CubicMeterConsumed = CubicMeterConsumed;
        Consumption.AmountToPay = amountToPay;
        
        notesService.UpdateNote(Consumption.Consumption);
    }
}