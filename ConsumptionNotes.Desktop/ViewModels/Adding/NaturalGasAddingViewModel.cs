using ConsumptionNotes.Desktop.ViewModels.Adding.Interfaces;
using ConsumptionNotes.Presentation.ViewModels.Adding;

namespace ConsumptionNotes.Desktop.ViewModels.Adding;

public class NaturalGasAddingViewModel : NaturalGasAddingViewModelBase, IAddingViewModel
{
    public AsyncRelayCommand AddNoteCommand { get; }
    
    public NaturalGasAddingViewModel(ObservableNaturalGasNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommand(AddNote);
    }
}