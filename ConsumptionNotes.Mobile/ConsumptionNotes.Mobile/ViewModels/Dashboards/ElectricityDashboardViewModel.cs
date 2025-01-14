using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Mobile.Commands;
using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public class ElectricityDashboardViewModel
    : BaseDashboardViewModel<ElectricityConsumption, ElectricityChartService, ElectricityNotesService>
{
    public GoToCommand OpenAddingPageCommand { get; } = new(nameof(ElectricityAddingPage), true);

    public ImportDataCommand ImportDataCommand { get; }
    public ExportDataCommand ExportDataCommand { get; }
    
    public ElectricityDashboardViewModel(ElectricityNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }
}