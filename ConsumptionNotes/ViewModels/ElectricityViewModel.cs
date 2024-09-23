using ConsumptionNotes.Views.Add;
using FluentAvalonia.UI.Controls;

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
    private void Remove(ElectricityConsumption consumption)
    {
        notesService.RemoveNote(consumption);
    }
}