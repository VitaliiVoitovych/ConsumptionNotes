using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Desktop.Commands;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Desktop.Views.Adding;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public class NaturalGasDashboardViewModel
    : BaseDashboardViewModel<NaturalGasConsumption, NaturalGasChartService, NaturalGasNotesService>
{
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand ExportDataCommand { get; }
    public AsyncRelayCommand OpenAddingDialogCommand { get; } =
        new OpenAddingDialogCommand<NaturalGasAddingView, NaturalGasAddingViewModel>();
    
    public NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }
}