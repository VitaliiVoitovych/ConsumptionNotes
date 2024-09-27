using ConsumptionNotes.Utils.Dialogs;
using ConsumptionNotes.Views.Addition;

namespace ConsumptionNotes.ViewModels;

public partial class ElectricityViewModel(ElectricityNotesService notesService) : ViewModelBase
{
    public ElectricityNotesService NotesService => notesService;
    public ElectricityChartService ChartService => notesService.ChartService;

    [RelayCommand]
    private async Task OpenAddDialog()
    {
        var addView = Ioc.Default.GetRequiredService<ElectricityNoteView>();
        var addViewModel = addView.DataContext as ElectricityNoteViewModel;

        var addDialog = Dialogs.CreateAdditionDialog(addView, addViewModel!.AddCommand);
        await addDialog.ShowAsync();
    }

    [RelayCommand]
    private void Remove(ElectricityConsumption consumption)
    {
        notesService.RemoveNote(consumption);
    }
}