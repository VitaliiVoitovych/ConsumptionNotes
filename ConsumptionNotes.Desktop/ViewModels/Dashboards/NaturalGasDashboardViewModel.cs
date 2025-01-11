using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Desktop.Views.Adding;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public class NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileSystemService fileSystemService)
    : BaseDashboardViewModel<NaturalGasConsumption, NaturalGasChartService, NaturalGasNotesService>(notesService,
        fileSystemService)
{
    protected override string ExportFileName => "naturalgas";
    protected override UserControl AddingView => Ioc.Default.GetRequiredService<NaturalGasAddingView>();
}