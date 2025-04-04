using ConsumptionNotes.Presentation.ViewModels.Dashboards;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public class NaturalGasDashboardViewModel
    : DashboardViewModelBase<NaturalGasConsumption, ObservableNaturalGasConsumption, NaturalGasChartService, ObservableNaturalGasNotesService>
{
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand<IEnumerable<NaturalGasConsumption>> ExportDataCommand { get; }

    public AsyncRelayCommand OpenAddingDialogCommand { get; } =
        new OpenAddingDialogCommand<NaturalGasConsumption, ObservableNaturalGasConsumption, NaturalGasAddingView>();
    
    public AsyncRelayCommand<ObservableNaturalGasConsumption> OpenEditingDialogCommand { get; } =
        new OpenEditingDialogCommand<NaturalGasConsumption, ObservableNaturalGasConsumption, NaturalGasEditingView>();
    
    public NaturalGasDashboardViewModel(ObservableNaturalGasNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand<NaturalGasConsumption,ObservableNaturalGasConsumption>(fileSystemService, NotesService);
        ExportDataCommand = new ExportDataCommand<NaturalGasConsumption>(fileSystemService);
    }
}