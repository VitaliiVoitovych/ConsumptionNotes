using ConsumptionNotes.Presentation.ViewModels.Adding;

namespace ConsumptionNotes.Mobile.ViewModels.Adding;

public class ElectricityAddingViewModel : ElectricityAddingViewModelBase
{
    public AsyncRelayCommand GoToBackCommand { get; } = new GoToCommand("..");
    
    public AsyncRelayCommand AddNoteCommand { get; }
    
    public ElectricityAddingViewModel(ObservableElectricityNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommand(AddNote);
    }
}
