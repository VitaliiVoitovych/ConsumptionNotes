namespace ConsumptionNotes.Presentation.ViewModels.Adding;

public abstract partial class ConsumptionAddingViewModelBase<TConsumption, TObservableConsumption, TNotesService>(TNotesService notesService)
    : ViewModelBase
    where TConsumption : BaseConsumption
    where TObservableConsumption : ObservableBaseConsumption<TConsumption>
    where TNotesService : IObservableNotesService<TConsumption, TObservableConsumption>
{
    private TNotesService _notesService = notesService;

    [ObservableProperty] private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
    
    protected abstract TObservableConsumption CreateConsumption();

    protected void AddNote()
    {
        var consumption = CreateConsumption();
        InvalidConsumptionDataException.ThrowIfDateInvalid(consumption.Consumption);
        _notesService.Add(consumption);
        UpdateDate();
    }

    private void UpdateDate() => SelectedDate = SelectedDate.AddMonths(1);
}