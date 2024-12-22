using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes;
using ConsumptionNotes.Mobile.Pages;

namespace ConsumptionNotes.Mobile.ViewModels;

public partial class NaturalGasDashboardViewModel(NaturalGasNotesService notesService) : ObservableObject
{
    public NaturalGasNotesService NotesService => notesService;
    public NaturalGasChartService ChartService => NotesService.ChartService;

    [RelayCommand]
    private async Task OpenAddPage()
    {
        await Shell.Current.GoToAsync(nameof(AddNaturalGasPage), true);
    }
}