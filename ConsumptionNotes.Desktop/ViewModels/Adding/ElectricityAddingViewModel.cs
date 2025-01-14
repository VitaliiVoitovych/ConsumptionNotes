using ConsumptionNotes.Application.ViewModels.Adding;
using ConsumptionNotes.Desktop.Commands;

namespace ConsumptionNotes.Desktop.ViewModels.Adding;

public class ElectricityAddingViewModel : BaseElectricityAddingViewModel
{
    public AddNoteCommands AddNoteCommand { get; }

    public ElectricityAddingViewModel(ElectricityNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommands(AddNote);
    }
}