using System.Linq;

namespace ConsumptionNotes.Services.Notes;

public abstract partial class BaseNotesService<TNote, TChartService> : ObservableObject
    where TNote : BaseConsumption
    where TChartService : BaseChartService<TNote>
{
    [ObservableProperty] private decimal _averageAmount;
    
    public TChartService ChartService { get; }

    public ObservableCollection<TNote> Consumptions { get; }
    
    protected BaseNotesService(TChartService chartService)
    {
        ChartService = chartService;
        Consumptions = [];
    }

    public void AddNote(TNote note)
    {
        if (Consumptions.Any(n => EqualsYearAndMonth(n.Date, note.Date)))
            throw new ArgumentException("Запис про цей місяць вже є");

        var lastConditionNote = Consumptions.LastOrDefault(n => n.Date < note.Date);
        var index = Consumptions.IndexOf(lastConditionNote!) + 1;
        
        Consumptions.Insert(index, note);
        ChartService.AddValues(index, note);
        
        UpdateAverageValues();
    }

    public void RemoveNote(TNote note)
    {
        var index = Consumptions.IndexOf(note);
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