using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Desktop.Views.Adding;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public class ElectricityDashboardViewModel(ElectricityNotesService notesService, FileSystemService fileSystemService)
    : BaseDashboardViewModel<ElectricityConsumption, ElectricityChartService, ElectricityNotesService>(notesService,
        fileSystemService)
{
    protected override string ExportFileName => "electricity";
    protected override UserControl AddingView => Ioc.Default.GetRequiredService<ElectricityNoteView>();
}