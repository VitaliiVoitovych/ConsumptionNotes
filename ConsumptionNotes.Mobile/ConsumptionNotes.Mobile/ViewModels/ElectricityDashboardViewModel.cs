using CommunityToolkit.Mvvm.ComponentModel;
using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes;

namespace ConsumptionNotes.Mobile.ViewModels;

public class ElectricityDashboardViewModel(ElectricityNotesService notesService) : ObservableObject
{
    public ElectricityNotesService NotesService => notesService;
    public ElectricityChartService ChartService => NotesService.ChartService;
}