using ConsumptionNotes.Presentation.ViewModels.Adding;
using ConsumptionNotes.Desktop.ViewModels.Adding.Interfaces;

namespace ConsumptionNotes.Desktop.ViewModels.Adding;

public class ElectricityAddingViewModel : ElectricityAddingViewModelBase, IAddingViewModel
{
    public AsyncRelayCommand AddNoteCommand { get; }
    
    public ElectricityAddingViewModel(ObservableElectricityNotesService notesService) : base(notesService)
    {
        AddNoteCommand = new AddNoteCommand(AddNote);
    }
}