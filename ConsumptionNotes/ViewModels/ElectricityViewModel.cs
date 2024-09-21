namespace ConsumptionNotes.ViewModels;

public class ElectricityViewModel(ElectricityNotesService notesService) : ViewModelBase
{
    public ElectricityNotesService NotesService => notesService;

    public ElectricityChartService ChartService => notesService.ChartService;
}