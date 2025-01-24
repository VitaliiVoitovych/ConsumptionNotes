using ConsumptionNotes.Application.Extensions;
using ConsumptionNotes.Application.Models;
using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes.Interfaces;
using ConsumptionNotes.Dal.Repositories.Base;
using ConsumptionNotes.Domain.Exceptions;
using ConsumptionNotes.Domain.Extensions;

namespace ConsumptionNotes.Application.Services.Notes;

public abstract partial class BaseNotesService<TConsumption, TObservableConsumption, TChartService, TRepository> 
    : ObservableObject, INotesChartService<TConsumption, TObservableConsumption, TChartService>
    where TConsumption : BaseConsumption
    where TObservableConsumption : ObservableBaseConsumption<TConsumption>
    where TChartService : BaseChartService<TConsumption>
    where TRepository : BaseRepository<TConsumption>
{
    [ObservableProperty] private decimal _averageAmount;
    private readonly TRepository _repository;
    
    public TChartService ChartService { get; }

    public ObservableCollection<TObservableConsumption> Consumptions { get; }
    
    protected BaseNotesService(TChartService chartService, TRepository repository)
    {
        ChartService = chartService;
        _repository = repository;
        Consumptions = [];
    }

    public async Task LoadDataAsync()
    {
        var consumptions = await _repository.GetAll();
        
        foreach (var consumption in consumptions)
        {
            Consumptions.Add(consumption.Convert<TConsumption, TObservableConsumption>());
            ChartService.AddValues(consumption);
        }
        UpdateAverageValues();
    }

    public async Task ImportDataAsync(IAsyncEnumerable<TConsumption> data)
    {
        Clear();
        
        await foreach (var consumption in data)
        {
            AddNote(consumption);
        }
    }

    private void Clear()
    {
        var consumptions = Consumptions.ToList();

        foreach (var consumption in consumptions)
        {
            RemoveNote(consumption.Consumption);
        }
    }
    
    public void AddNote(TConsumption consumption)
    {
        DuplicateConsumptionNoteException.ThrowIfDuplicateExists(Consumptions.ToConsumptionsList<TConsumption, TObservableConsumption>(), consumption);
        
        var index = Consumptions.LastMatchingIndex(c => c.Date < consumption.Date) + 1;
        
        Consumptions.Insert(index, consumption.Convert<TConsumption, TObservableConsumption>());
        ChartService.AddValues(index, consumption);

        _repository.Add(consumption);
        
        UpdateAverageValues();
    }

    public void RemoveNote(TConsumption consumption)
    {
        var index = Consumptions.IndexOf(consumption.Convert<TConsumption, TObservableConsumption>());
        Consumptions.RemoveAt(index);
        ChartService.RemoveValues(index);

        _repository.Remove(consumption);
        
        UpdateAverageValues();
    }

    public void UpdateNote(TConsumption consumption)
    {
        var index = Consumptions.LastMatchingIndex(c => c.Date == consumption.Date);
        
        ChartService.UpdateValues(index, consumption);
        
        _repository.Update(Consumptions[index].Consumption);
        UpdateAverageValues();
    }
    
    protected virtual void UpdateAverageValues()
    {
        AverageAmount = Consumptions.Count > 0 
            ? Consumptions.Average(e => e.AmountToPay) 
            : 0.0m;
    }
}