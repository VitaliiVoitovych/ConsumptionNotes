using ConsumptionNotes.Domain.Extensions;
using ConsumptionNotes.Infrastructure.Notes.Services.Interfaces;

namespace ConsumptionNotes.Presentation.Notes.Services;

public abstract partial class ObservableNotesServiceBase<TConsumption, TObservableConsumption, TChartService, TNotesService>
    : ObservableObject, IObservableNotesChartService<TConsumption, TObservableConsumption, TChartService>
    where TConsumption : BaseConsumption
    where TObservableConsumption : ObservableBaseConsumption<TConsumption>
    where TChartService : ConsumptionChartServiceBase<TConsumption>
    where TNotesService : INotesService<TConsumption>
{
    [ObservableProperty] private TObservableConsumption? _lastRecord;
    [ObservableProperty] private decimal _averageAmount;
    
    public TChartService ChartService { get; }
    public TNotesService NotesService { get; }
    
    public ObservableCollection<TObservableConsumption> ObservableConsumptions { get; }

    public List<TConsumption> Consumptions => NotesService.Consumptions;
    
    protected ObservableNotesServiceBase(TChartService chartService, TNotesService notesService)
    {
        ChartService = chartService;
        NotesService = notesService;
        ObservableConsumptions = [];
    }

    protected abstract TObservableConsumption ToObservableConsumptionObject(TConsumption consumption);
    
    private void Clear()
    {
        ObservableConsumptions.Clear();
        ChartService.ClearValues();
    }
    
    public async Task LoadDataAsync()
    {
        await NotesService.LoadDataAsync();

        // TODO: Improve
        foreach (var consumption in NotesService.Consumptions)
        {
            var observableConsumption = ToObservableConsumptionObject(consumption);
            ObservableConsumptions.Add(observableConsumption);
            
            ChartService.AddValues(consumption);
        }
        
        UpdateAverageValues();
        UpdateLastRecord();
    }

    public async Task ImportDataAsync(IAsyncEnumerable<TConsumption> data)
    {
        Clear();
        
        await NotesService.ImportDataAsync(data);
        
        foreach (var consumption in NotesService.Consumptions)
        {
            var observableConsumption = ToObservableConsumptionObject(consumption);
            ObservableConsumptions.Add(observableConsumption);
            
            ChartService.AddValues(consumption);
        }
        
        UpdateAverageValues();
        UpdateLastRecord();
    }
    
    public void Add(TObservableConsumption observableConsumption)
    {
        NotesService.Add(observableConsumption.Consumption);
        
        var index = ObservableConsumptions.LastMatchingIndex(c => c.Date < observableConsumption.Date) + 1;
        ObservableConsumptions.Insert(index, observableConsumption);
        ChartService.InsertValues(index, observableConsumption.Consumption);
        
        UpdateAverageValues();
        UpdateLastRecord();
    }

    public void Remove(TObservableConsumption observableConsumption)
    {
        NotesService.Remove(observableConsumption.Consumption);
        
        var index = ObservableConsumptions.LastMatchingIndex(c => c.Date == observableConsumption.Date);
        ObservableConsumptions.RemoveAt(index);
        ChartService.RemoveValues(index);
        
        UpdateAverageValues();
        UpdateLastRecord();
    }

    public void Update(TObservableConsumption consumption)
    {
        NotesService.Update(consumption.Consumption);
        
        var index = ObservableConsumptions.LastMatchingIndex(c => c.Date == consumption.Date);
        
        ChartService.UpdateValues(index, consumption.Consumption);
        
        UpdateAverageValues();
        UpdateLastRecord();
    }
    
    protected virtual void UpdateAverageValues()
    {
        AverageAmount = NotesService.AverageAmount;
    }

    private void UpdateLastRecord()
    {
        LastRecord = ObservableConsumptions.LastOrDefault();
    }
}