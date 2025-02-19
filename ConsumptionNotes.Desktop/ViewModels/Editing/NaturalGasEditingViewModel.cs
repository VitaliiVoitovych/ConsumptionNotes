using ConsumptionNotes.Presentation.ViewModels.Editing;

namespace ConsumptionNotes.Desktop.ViewModels.Editing;

public class NaturalGasEditingViewModel(ObservableNaturalGasNotesService notesService) 
    : NaturalGasEditingViewModelBase(notesService)
{
    public void SetConsumption(ObservableNaturalGasConsumption consumption)
    {
        Consumption = consumption;
        
        CubicMeterConsumed = Consumption.CubicMeterConsumed;
    }
}