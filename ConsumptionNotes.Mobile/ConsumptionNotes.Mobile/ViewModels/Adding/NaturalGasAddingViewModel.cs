using ConsumptionNotes.Application.ViewModels.Adding;
using ConsumptionNotes.Mobile.Commands;

namespace ConsumptionNotes.Mobile.ViewModels.Adding;

public class NaturalGasAddingViewModel : BaseNaturalGasAddingViewModel
{
    public AsyncRelayCommand GoToBackCommand { get; } = new GoToCommand("", true);
    
    public NaturalGasAddingViewModel(NaturalGasNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommand(AddNote);
    }
}
