using ConsumptionNotes.Application.Models;
using ConsumptionNotes.Application.Services.Charting;

namespace ConsumptionNotes.Application.Services.Notes.Interfaces;

public interface INotesChartService<TConsumption, TObservableConsumption,TChartService> 
    : INotesService<TConsumption, TObservableConsumption>
    where TConsumption : BaseConsumption
    where TObservableConsumption : ObservableBaseConsumption<TConsumption>
    where TChartService : BaseChartService<TConsumption>
{
    TChartService ChartService { get; }
}

public interface INotesService<TConsumption, TObservableConsumption>
    where TConsumption : BaseConsumption
    where TObservableConsumption : ObservableBaseConsumption<TConsumption>
{
    ObservableCollection<TObservableConsumption> Consumptions { get; }
    Task ImportDataAsync(IAsyncEnumerable<TConsumption> data);
    void AddNote(TConsumption consumption);
    void RemoveNote(TConsumption consumption);
    void UpdateNote(TConsumption consumption);
}