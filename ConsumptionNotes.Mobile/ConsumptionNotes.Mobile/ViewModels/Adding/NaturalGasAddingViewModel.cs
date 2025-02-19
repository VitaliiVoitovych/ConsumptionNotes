using ConsumptionNotes.Presentation.ViewModels.Adding;

namespace ConsumptionNotes.Mobile.ViewModels.Adding;

public class NaturalGasAddingViewModel : NaturalGasAddingViewModelBase
{
    public AsyncRelayCommand GoToBackCommand { get; } = new GoToCommand("..", true);
    public AsyncRelayCommand AddNoteCommand { get; }
    
    public NaturalGasAddingViewModel(ObservableNaturalGasNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommand(AddNote);
    }
}
