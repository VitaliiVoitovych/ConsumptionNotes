namespace ConsumptionNotes.Presentation.ViewModels.Adding;

public abstract partial class ConsumptionAddingViewModelBase<TConsumption, TObservableConsumption>(IObservableNotesService<TConsumption, TObservableConsumption> notesService)
    : ViewModelBase
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
{
    [ObservableProperty] private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
    
    protected abstract TObservableConsumption CreateConsumption();

    public void AddNote()
    {
        var consumption = CreateConsumption();
        InvalidConsumptionDataException.ThrowIfDateInvalid(consumption.Consumption);
        notesService.Add(consumption);
        UpdateDate();
    }

    private void UpdateDate() => SelectedDate = SelectedDate.AddMonths(1);
}