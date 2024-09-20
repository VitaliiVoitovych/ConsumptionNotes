using CommunityToolkit.Mvvm.ComponentModel;

namespace ConsumptionNotes.Services.Notes;

public abstract class BaseNotesService<TNote, TChartService> : ObservableObject
    where TNote : BaseConsumption
    where TChartService : BaseChartService<TNote>
{
    public TChartService ChartService { get; }

    protected BaseNotesService(TChartService chartService)
    {
        ChartService = chartService;
    }
    
    public abstract void AddNote(TNote note);
    public abstract void RemoveNote(TNote note);
    protected abstract void UpdateAverageValues();
    
    protected bool EqualsYearAndMonth(DateOnly date1, DateOnly date2)
        => (date1.Month, date1.Year) == (date2.Month, date2.Year);
}