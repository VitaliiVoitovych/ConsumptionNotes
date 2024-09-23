using ConsumptionNotes.Views.Add;
using FluentAvalonia.UI.Controls;

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
        
        var addDialog = new ContentDialog
        {
            PrimaryButtonText = "Додати",
            CloseButtonText = "Відмінити",
            Title = "Новий запис",
            Content = addView,
            PrimaryButtonCommand = addViewModel?.AddCommand,
            DefaultButton = ContentDialogButton.Primary,
        };

        await addDialog.ShowAsync();
    }

    [RelayCommand]
    private void Remove(NaturalGasConsumption consumption)
    {
        notesService.RemoveNote(consumption);
    }
}