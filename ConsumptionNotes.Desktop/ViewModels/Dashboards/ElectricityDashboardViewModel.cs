using ConsumptionNotes.Presentation.ViewModels.Dashboards;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public class ElectricityDashboardViewModel
    : DashboardViewModelBase<ElectricityConsumption, ObservableElectricityConsumption, ElectricityChartService, ObservableElectricityNotesService>
{
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand<IEnumerable<ElectricityConsumption>> ExportDataCommand { get; }

    public AsyncRelayCommand OpenAddingDialogCommand { get; } =
        new OpenAddingDialogCommand<ElectricityConsumption, ObservableElectricityConsumption, ElectricityAddingView>();
    
    public AsyncRelayCommand<ObservableElectricityConsumption> OpenEditingDialogCommand { get; } =
        new OpenEditingDialogCommand<ElectricityConsumption, ObservableElectricityConsumption,
            ElectricityEditingView>();
    
    public ElectricityDashboardViewModel(ObservableElectricityNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand<ElectricityConsumption, ObservableElectricityConsumption>(fileSystemService, NotesService);
        ExportDataCommand = new ExportDataCommand<ElectricityConsumption>(fileSystemService);
    }
}