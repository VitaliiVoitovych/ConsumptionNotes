namespace ConsumptionNotes.Presentation.ViewModels.Editing;

public abstract partial class ConsumptionEditingViewModelBase<TConsumption, TObservableConsumption>(
    IObservableNotesService<TConsumption, TObservableConsumption> notesService) 
    : ViewModelBase
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
{
    public TObservableConsumption Consumption { get; protected set; } = null!;

    public abstract void SetConsumption(TObservableConsumption consumption);
    
    [RelayCommand]
    protected virtual void Update()
    {
        notesService.Update(Consumption);
    }
}