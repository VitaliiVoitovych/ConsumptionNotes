using ConsumptionNotes.Presentation.ViewModels.Editing;

namespace ConsumptionNotes.Mobile.ViewModels.Editing;

public class ElectricityEditingViewModel(ObservableElectricityNotesService notesService)
    : ElectricityEditingViewModelBase(notesService), IQueryAttributable
{
    public AsyncRelayCommand GoToBackCommand { get; } = new GoToCommand("..", true);

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Consumption = (ObservableElectricityConsumption)query[nameof(Consumption)];
        OnPropertyChanged(nameof(Consumption));
        
        DayKilowattConsumed = Consumption.DayKilowattConsumed;
        NightKilowattConsumed = Consumption.NightKilowattConsumed;
    }
}