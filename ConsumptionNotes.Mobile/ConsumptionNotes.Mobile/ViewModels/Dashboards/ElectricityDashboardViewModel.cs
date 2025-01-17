using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Mobile.Commands;
using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public class ElectricityDashboardViewModel
    : BaseDashboardViewModel<ElectricityConsumption, ElectricityChartService, ElectricityNotesService>
{
    public AsyncRelayCommand OpenAddingPageCommand { get; } = new GoToCommand(nameof(ElectricityAddingPage), true);

    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand ExportDataCommand { get; }
    
    public ElectricityDashboardViewModel(ElectricityNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }
}