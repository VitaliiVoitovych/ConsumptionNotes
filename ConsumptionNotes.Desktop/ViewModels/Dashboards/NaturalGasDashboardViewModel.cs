using ConsumptionNotes.Desktop.Services.Charting;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Desktop.Services.Notes;
using ConsumptionNotes.Desktop.Views.Addition;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public partial class NaturalGasDashboardViewModel 
    : BaseDashboardViewModel<NaturalGasConsumption, NaturalGasChartService, NaturalGasNotesService>
{
    protected override string ExportFileName => "naturalgas";

    public NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileService fileService)
        : base(notesService, fileService)
    {
        
    }
    
    protected override BaseNoteView GetNoteView()
    {
        return Ioc.Default.GetRequiredService<NaturalGasNoteView>();
    }
}