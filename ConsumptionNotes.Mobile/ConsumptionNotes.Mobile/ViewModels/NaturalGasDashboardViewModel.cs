using CommunityToolkit.Mvvm.ComponentModel;
using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes;

namespace ConsumptionNotes.Mobile.ViewModels;

public class NaturalGasDashboardViewModel(NaturalGasNotesService notesService) : ObservableObject
{
    public NaturalGasNotesService NotesService => notesService;
    public NaturalGasChartService ChartService => NotesService.ChartService;
}