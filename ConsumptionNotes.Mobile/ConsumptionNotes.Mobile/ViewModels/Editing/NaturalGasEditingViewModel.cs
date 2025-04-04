using ConsumptionNotes.Presentation.ViewModels.Editing;

namespace ConsumptionNotes.Mobile.ViewModels.Editing;

public class NaturalGasEditingViewModel(ObservableNaturalGasNotesService notesService) 
    : NaturalGasEditingViewModelBase(notesService), IQueryAttributable
{
    public AsyncRelayCommand GoToBackCommand { get; } = new GoToCommand("..");

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        SetConsumption((ObservableNaturalGasConsumption)query[nameof(Consumption)]);
        
        OnPropertyChanged(nameof(Consumption));
    }
}