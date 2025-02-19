namespace ConsumptionNotes.Infrastructure.Notes.Services.Interfaces;

public interface INotesService<TConsumption>
    where TConsumption : BaseConsumption
{
    decimal AverageAmount { get; }
    
    List<TConsumption> Consumptions { get; }
    
    Task LoadDataAsync();
    Task ImportDataAsync(IAsyncEnumerable<TConsumption> data);

    void Add(TConsumption consumption);
    void Remove(TConsumption consumption);
    void Update(TConsumption consumption);
}