using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Utils.Dialogs;
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
    
    [RelayCommand]
    private async Task OpenAddDialog()
    {
        var addView = Ioc.Default.GetRequiredService<NaturalGasNoteView>();
        var addViewModel = addView.DataContext as NaturalGasNoteViewModel;

        await Dialogs.ShowAdditionDialog(addView, addViewModel!.AddCommand);
    }
}