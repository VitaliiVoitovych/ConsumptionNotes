using ConsumptionNotes.Application.Services;
using ConsumptionNotes.Application.ViewModels;

namespace ConsumptionNotes.Desktop.ViewModels.Editing;

public partial class NaturalGasEditingViewModel(NaturalGasNotesService notesService) : ViewModelBase
{
    public NaturalGasConsumption Consumption { get; private set; }
    
    [ObservableProperty] private double _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.95689m;
    
    public void SetConsumption(NaturalGasConsumption consumption)
    {
        Consumption = consumption;

        CubicMeterConsumed = Consumption.CubicMeterConsumed;
    }
    
    [RelayCommand]
    private void Update()
    {
        var amountToPay = PaymentCalculator.CalculateNaturalGasPayment(CubicMeterConsumed, CubicMeterPrice);
        
        Consumption.CubicMeterConsumed = CubicMeterConsumed;
        Consumption.AmountToPay = amountToPay;
        
        notesService.UpdateNote(Consumption);
    }
}