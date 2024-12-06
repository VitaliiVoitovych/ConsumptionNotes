using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Application.Services.Notes;
using ConsumptionNotes.Desktop.Views.Addition;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

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