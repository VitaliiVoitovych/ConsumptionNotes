using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Views.Addition;

namespace ConsumptionNotes.ViewModels.Dashboards;

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