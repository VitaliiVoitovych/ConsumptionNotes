using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes;
using ConsumptionNotes.Domain.Models;
using ConsumptionNotes.Mobile.Pages;

namespace ConsumptionNotes.Mobile.ViewModels;

public partial class ElectricityDashboardViewModel(ElectricityNotesService notesService) : ObservableObject
{
    public ElectricityNotesService NotesService => notesService;
    public ElectricityChartService ChartService => NotesService.ChartService;

    [RelayCommand]
    private void Remove(ElectricityConsumption consumption)
    {
        NotesService.RemoveNote(consumption);
    }

    [RelayCommand]
    private async Task OpenAddPage()
    {
        await Shell.Current.GoToAsync(nameof(AddElectricityPage), true);
    }
}