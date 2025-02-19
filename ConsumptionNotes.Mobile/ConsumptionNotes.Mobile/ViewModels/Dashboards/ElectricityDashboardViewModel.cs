using ConsumptionNotes.Presentation.ViewModels.Dashboards;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;
public class ElectricityDashboardViewModel
    : DashboardViewModelBase<ElectricityConsumption, ObservableElectricityConsumption, ElectricityChartService, ObservableElectricityNotesService>
{
    public AsyncRelayCommand OpenAddingPageCommand { get; } = new GoToCommand(nameof(ElectricityAddingPage), true);
    
    public AsyncRelayCommand<ObservableElectricityConsumption> OpenEditingPageCommand { get; } =
        new GoToCommand<ObservableElectricityConsumption>(nameof(ElectricityEditingPage), "Consumption", true);
    
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand<IEnumerable<ElectricityConsumption>> ExportDataCommand { get; }
    
    public ElectricityDashboardViewModel(ObservableElectricityNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand<ElectricityConsumption, ObservableElectricityConsumption>(fileSystemService, NotesService);
        ExportDataCommand = new ExportDataCommand<ElectricityConsumption>(fileSystemService, ExportFilename);
    }
}