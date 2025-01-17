using ConsumptionNotes.Application.ViewModels.Adding;
using ConsumptionNotes.Mobile.Commands;

namespace ConsumptionNotes.Mobile.ViewModels.Adding;

public class ElectricityAddingViewModel : BaseElectricityAddingViewModel
{
    public AsyncRelayCommand GoToBackCommand { get; } = new GoToCommand("..", true);
    
    public ElectricityAddingViewModel(ElectricityNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommand(AddNote);
    }
}
