using ConsumptionNotes.Dal.Repositories.Base;
using ConsumptionNotes.Domain.Exceptions;
using ConsumptionNotes.Domain.Extensions;
using ConsumptionNotes.Infrastructure.Notes.Services.Interfaces;

namespace ConsumptionNotes.Infrastructure.Notes.Services;

public abstract class ConsumptionNotesServiceBase<TConsumption, TRepository> : INotesService<TConsumption>
    where TConsumption : ConsumptionBase
    where TRepository : RepositoryBase<TConsumption>
{
    private readonly TRepository _repository;
    
    public decimal AverageAmount { get; private set; }
    
    public List<TConsumption> Consumptions { get; }

    protected ConsumptionNotesServiceBase(TRepository repository)
    {
        _repository = repository;
        Consumptions = [];
    }

    private void Clear()
    {
        foreach (var consumption in new List<TConsumption>(Consumptions))
        {
            Remove(consumption);
        }
    }
    
    public async Task LoadDataAsync()
    {
        var consumptions = await _repository.GetAll();
        Consumptions.AddRange(consumptions);
        
        UpdateAverageValues();
    }

    public async Task ImportDataAsync(IAsyncEnumerable<TConsumption> data)
    {
        Clear();

        await foreach (var consumption in data)
        {
            Add(consumption);
        }
    }
    
    public void Add(TConsumption consumption)
    {
        DuplicateConsumptionNoteException.ThrowIfDuplicateExists(Consumptions, consumption);

        var index = Consumptions.LastMatchingIndex(c => c.Date < consumption.Date) + 1;
        
        Consumptions.Insert(index, consumption);

        _repository.Add(consumption);
        
        UpdateAverageValues();
    }

    public void Remove(TConsumption consumption)
    {
        Consumptions.Remove(consumption);

        _repository.Remove(consumption);
        
        UpdateAverageValues();
    }

    public void Update(TConsumption consumption)
    {
        _repository.Update(consumption);
        
        UpdateAverageValues();
    }
    
    protected virtual void UpdateAverageValues()
    {
        AverageAmount = Consumptions.Count > 0 ? Consumptions.Average(c => c.AmountToPay) : 0.0m;
    }
}