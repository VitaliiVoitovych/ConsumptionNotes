using ConsumptionNotes.Application.ViewModels.Adding;
using ConsumptionNotes.Mobile.Commands;

namespace ConsumptionNotes.Mobile.ViewModels.Adding;

public class NaturalGasAddingViewModel : BaseNaturalGasAddingViewModel
{
    public GoToCommand GoToBackCommand { get; } = new("", true);
    
    public AddNoteCommand AddNoteCommand { get; }

    public NaturalGasAddingViewModel(NaturalGasNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommand(AddNote);
    }
}
