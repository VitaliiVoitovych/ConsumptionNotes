using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Views.Addition;

namespace ConsumptionNotes.ViewModels.Dashboards;

public partial class ElectricityDashboardViewModel 
    : BaseDashboardViewModel<ElectricityConsumption, ElectricityChartService, ElectricityNotesService>
{
    protected override string ExportFileName => "electricity";

    public ElectricityDashboardViewModel(ElectricityNotesService notesService, FileService fileService)
        : base(notesService, fileService)
    {
        
    }
    
    protected override BaseNoteView GetNoteView()
    {
        return Ioc.Default.GetRequiredService<ElectricityNoteView>();
    }
}