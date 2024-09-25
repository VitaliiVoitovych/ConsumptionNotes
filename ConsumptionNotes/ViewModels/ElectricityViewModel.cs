using ConsumptionNotes.Utils.Dialogs;
using ConsumptionNotes.Views.Add;

namespace ConsumptionNotes.ViewModels;

public partial class ElectricityViewModel(ElectricityNotesService notesService) : ViewModelBase
{
    public ElectricityNotesService NotesService => notesService;
    public ElectricityChartService ChartService => notesService.ChartService;

    [RelayCommand]
    private async Task OpenAddDialog()
    {
        var addView = Ioc.Default.GetRequiredService<ElectricityAddView>();
        var addViewModel = addView.DataContext as ElectricityAddViewModel;

        var addDialog = Dialogs.CreateAdditionDialog(addView, addViewModel!.AddCommand);
        await addDialog.ShowAsync();
    }

    [RelayCommand]
    private void Remove(ElectricityConsumption consumption)
    {
        notesService.RemoveNote(consumption);
    }
}