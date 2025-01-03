using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public partial class ElectricityDashboardViewModel(ElectricityNotesService notesService, FileService fileService)
    : BaseDashboardViewModel<ElectricityConsumption, ElectricityChartService, ElectricityNotesService>(notesService, fileService)
{
    protected override string ExportFileName => "electricity";

    protected override string AddPageRoute => nameof(AddElectricityPage);
}