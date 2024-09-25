using ConsumptionNotes.Utils.Dialogs;
using ConsumptionNotes.Views.Add;

namespace ConsumptionNotes.ViewModels;

public partial class NaturalGasViewModel(NaturalGasNotesService notesService) : ViewModelBase
{
    public NaturalGasNotesService NotesService => notesService;
    public NaturalGasChartService ChartService => notesService.ChartService;
    
    [RelayCommand]
    private async Task OpenAddDialog()
    {
        var addView = Ioc.Default.GetRequiredService<NaturalGasAddView>();
        var addViewModel = addView.DataContext as NaturalGasAddViewModel;

        var addDialog = Dialogs.CreateAdditionDialog(addView, addViewModel!.AddCommand);
        await addDialog.ShowAsync();
    }

    [RelayCommand]
    private void Remove(NaturalGasConsumption consumption)
    {
        notesService.RemoveNote(consumption);
    }
}