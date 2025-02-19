using ConsumptionNotes.Presentation.ViewModels.Editing;

namespace ConsumptionNotes.Desktop.ViewModels.Editing;

public class ElectricityEditingViewModel(ObservableElectricityNotesService notesService) 
    : ElectricityEditingViewModelBase(notesService)
{
    public void SetConsumption(ObservableElectricityConsumption consumption)
    {
        Consumption = consumption;

        DayKilowattConsumed = Consumption.DayKilowattConsumed;
        NightKilowattConsumed = Consumption.NightKilowattConsumed;
    }
}