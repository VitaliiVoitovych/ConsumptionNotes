using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public partial class NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileService fileService)
    : BaseDashboardViewModel<NaturalGasConsumption, NaturalGasChartService, NaturalGasNotesService>(notesService, fileService)
{
    protected override string ExportFileName => "naturalgas";

    protected override string AddPageRoute => nameof(AddNaturalGasPage);
}