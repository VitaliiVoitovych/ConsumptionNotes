using System.Linq;
using ConsumptionNotes.Domain.Extensions;
using ConsumptionNotes.Services.Notes.Interfaces;

namespace ConsumptionNotes.Services.Notes;

public abstract partial class BaseNotesService<TConsumption, TChartService> : ObservableObject, INotesService<TConsumption>
    where TConsumption : BaseConsumption
    where TChartService : BaseChartService<TConsumption>
{
    [ObservableProperty] private decimal _averageAmount;
    
    public TChartService ChartService { get; }

    public ObservableCollection<TConsumption> Consumptions { get; }
    
    protected BaseNotesService(TChartService chartService)
    {
        ChartService = chartService;
        Consumptions = [];
    }

    public void AddNote(TConsumption consumption)
    {
        if (Consumptions.Any(c => EqualsYearAndMonth(c.Date, consumption.Date)))
            throw new ArgumentException("Запис про цей місяць вже є");

        var index = Consumptions.LastMatchingIndex(c => c.Date < consumption.Date) + 1;
        
        Consumptions.Insert(index, consumption);
        ChartService.AddValues(index, consumption);
        
        UpdateAverageValues();
    }

    public void RemoveNote(TConsumption consumption)
    {
        var index = Consumptions.IndexOf(consumption);
        Consumptions.RemoveAt(index);
        ChartService.RemoveValues(index);
        
        UpdateAverageValues();
    }

    protected virtual void UpdateAverageValues()
    {
        AverageAmount = Consumptions.Count > 0 
            ? Consumptions.Average(e => e.AmountToPay) 
            : 0.0m;
    }
    
    private static bool EqualsYearAndMonth(DateOnly date1, DateOnly date2)
        => (date1.Month, date1.Year) == (date2.Month, date2.Year);
}