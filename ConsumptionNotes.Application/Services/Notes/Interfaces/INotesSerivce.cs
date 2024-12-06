using ConsumptionNotes.Application.Services.Charting;

namespace ConsumptionNotes.Application.Services.Notes.Interfaces;

public interface INotesChartService<TConsumption, TChartService> : INotesService<TConsumption>
    where TConsumption : BaseConsumption
    where TChartService : BaseChartService<TConsumption>
{
    TChartService ChartService { get; }
}

public interface INotesService<TConsumption>
    where TConsumption : BaseConsumption
{
    ObservableCollection<TConsumption> Consumptions { get; }
    Task ImportDataAsync(IAsyncEnumerable<TConsumption> data);
    void AddNote(TConsumption consumption);
    void RemoveNote(TConsumption consumption);
}