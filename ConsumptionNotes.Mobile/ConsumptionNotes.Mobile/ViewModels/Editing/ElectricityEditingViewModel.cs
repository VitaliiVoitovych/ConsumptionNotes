using ConsumptionNotes.Application.Services;
using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Mobile.Commands;

namespace ConsumptionNotes.Mobile.ViewModels.Editing;

public partial class ElectricityEditingViewModel(ElectricityNotesService notesService)
    : ViewModelBase, IQueryAttributable
{
    [ObservableProperty] private ElectricityConsumption _consumption;

    [ObservableProperty] private int _dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;

    public AsyncRelayCommand GoToBackCommand { get; } = new GoToCommand("..", true);
    
    [RelayCommand]
    private void Update()
    {
        var amountToPay =
            PaymentCalculator.CalculateElectricityPayment(DayKilowattConsumed, NightKilowattConsumed,
                KilowattPerHourPrice);
        
        Consumption.DayKilowattConsumed = DayKilowattConsumed;
        Consumption.NightKilowattConsumed = NightKilowattConsumed;
        Consumption.AmountToPay = amountToPay;
        
        notesService.UpdateNote(Consumption);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Consumption = (ElectricityConsumption)query[nameof(Consumption)];

        DayKilowattConsumed = Consumption.DayKilowattConsumed;
        NightKilowattConsumed = Consumption.NightKilowattConsumed;
    }
}