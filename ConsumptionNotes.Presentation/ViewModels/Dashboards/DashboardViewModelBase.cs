namespace ConsumptionNotes.Presentation.ViewModels.Dashboards;

public partial class DashboardViewModelBase<TConsumption, TObservableConsumption, TChartService, TNotesService>(
    TNotesService notesService)
    : ViewModelBase
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
    where TChartService : ConsumptionChartServiceBase<TConsumption>
    where TNotesService : IObservableNotesChartService<TConsumption, TObservableConsumption, TChartService>
{
    protected readonly string ExportFilename = typeof(TConsumption).Name;

    public TNotesService NotesService { get; } = notesService;
    public TChartService ChartService => NotesService.ChartService;

    [RelayCommand]
    private void Remove(TObservableConsumption consumption)
    {
        NotesService.Remove(consumption);
    }
}