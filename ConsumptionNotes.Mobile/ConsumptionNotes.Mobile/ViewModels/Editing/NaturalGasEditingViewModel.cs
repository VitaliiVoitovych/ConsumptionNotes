using ConsumptionNotes.Presentation.ViewModels.Editing;

namespace ConsumptionNotes.Mobile.ViewModels.Editing;

public class NaturalGasEditingViewModel(ObservableNaturalGasNotesService notesService) 
    : NaturalGasEditingViewModelBase(notesService), IQueryAttributable
{
    public AsyncRelayCommand GoToBackCommand { get; } = new GoToCommand("..", true);

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Consumption = (ObservableNaturalGasConsumption)query[nameof(Consumption)];
        OnPropertyChanged(nameof(Consumption));
        
        CubicMeterConsumed = Consumption.CubicMeterConsumed;
    }
}