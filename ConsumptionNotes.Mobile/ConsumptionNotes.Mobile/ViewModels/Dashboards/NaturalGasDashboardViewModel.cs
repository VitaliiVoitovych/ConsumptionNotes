using ConsumptionNotes.Presentation.ViewModels.Dashboards;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public class NaturalGasDashboardViewModel
    : DashboardViewModelBase<NaturalGasConsumption, ObservableNaturalGasConsumption, NaturalGasChartService, ObservableNaturalGasNotesService>
{
    public AsyncRelayCommand OpenAddingPageCommand { get; } = new GoToCommand(nameof(NaturalGasAddingPage), true);

    public AsyncRelayCommand<ObservableNaturalGasConsumption> OpenEditingPageCommand { get; } =
        new GoToCommand<ObservableNaturalGasConsumption>(nameof(NaturalGasEditingPage), "Consumption", true);
    
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand<IEnumerable<NaturalGasConsumption>> ExportDataCommand { get; }
    
    public NaturalGasDashboardViewModel(ObservableNaturalGasNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand<NaturalGasConsumption, ObservableNaturalGasConsumption>(fileSystemService, NotesService);
        ExportDataCommand = new ExportDataCommand<NaturalGasConsumption>(fileSystemService, ExportFilename);
    }
}