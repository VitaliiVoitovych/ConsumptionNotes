namespace ConsumptionNotes.ViewModels;

public class NaturalGasViewModel(NaturalGasNotesService notesService) : ViewModelBase
{
    public NaturalGasNotesService NotesService => notesService;
    public NaturalGasChartService ChartService => notesService.ChartService;
}