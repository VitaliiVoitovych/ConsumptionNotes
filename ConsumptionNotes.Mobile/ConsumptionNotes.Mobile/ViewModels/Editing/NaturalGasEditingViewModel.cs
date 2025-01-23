using ConsumptionNotes.Application.Services;
using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Mobile.Commands;

namespace ConsumptionNotes.Mobile.ViewModels.Editing;

public partial class NaturalGasEditingViewModel(NaturalGasNotesService notesService) 
    : ViewModelBase, IQueryAttributable
{
    [ObservableProperty] private NaturalGasConsumption _consumption;

    [ObservableProperty] private double _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.95689m;
    
    public AsyncRelayCommand GoToBackCommand { get; } = new GoToCommand("..", true);


    [RelayCommand]
    private void Update()
    {
        var amountToPay = PaymentCalculator.CalculateNaturalGasPayment(CubicMeterConsumed, CubicMeterPrice);
        
        Consumption.CubicMeterConsumed = CubicMeterConsumed;
        Consumption.AmountToPay = amountToPay;
        
        notesService.UpdateNote(Consumption);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Consumption = (NaturalGasConsumption)query[nameof(Consumption)];

        CubicMeterConsumed = Consumption.CubicMeterConsumed;
    }
}