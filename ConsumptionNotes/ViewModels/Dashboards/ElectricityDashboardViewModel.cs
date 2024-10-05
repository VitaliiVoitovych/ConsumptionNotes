using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Utils.Dialogs;
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
    
    [RelayCommand]
    private async Task OpenAddDialog()
    {
        var addView = Ioc.Default.GetRequiredService<ElectricityNoteView>();
        var addViewModel = addView.DataContext as ElectricityNoteViewModel;

        await Dialogs.ShowAdditionDialog(addView, addViewModel!.AddCommand);
    }
}