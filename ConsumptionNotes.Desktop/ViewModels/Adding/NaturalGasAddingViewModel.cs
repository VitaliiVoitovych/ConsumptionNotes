using ConsumptionNotes.Application.ViewModels.Adding;
using ConsumptionNotes.Desktop.Commands;

namespace ConsumptionNotes.Desktop.ViewModels.Adding;

public class NaturalGasAddingViewModel : BaseNaturalGasAddingViewModel
{
    public AddNoteCommands AddNoteCommand { get; }
    
    public NaturalGasAddingViewModel(NaturalGasNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommands(AddNote);
    }
}