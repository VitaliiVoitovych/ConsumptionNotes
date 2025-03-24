namespace ConsumptionNotes.Presentation.ViewModels.Editing;

public abstract partial class ConsumptionEditingViewModelBase<TConsumption, TObservableConsumption, TNotesService>(
    TNotesService notesService) 
    : ViewModelBase
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
    where TNotesService : IObservableNotesService<TConsumption, TObservableConsumption>
{
    private TNotesService _notesService = notesService;
    
    public TObservableConsumption Consumption { get; protected set; }

    [RelayCommand]
    protected virtual void Update()
    {
        _notesService.Update(Consumption);
    }
}