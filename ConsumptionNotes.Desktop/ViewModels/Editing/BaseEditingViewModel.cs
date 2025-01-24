using ConsumptionNotes.Application.Models;
using ConsumptionNotes.Application.ViewModels;

namespace ConsumptionNotes.Desktop.ViewModels.Editing;

public abstract partial class BaseEditingViewModel<TConsumption, TObservableConsumption> : ViewModelBase
    where TConsumption : BaseConsumption
    where TObservableConsumption : ObservableBaseConsumption<TConsumption>
{
    public TObservableConsumption Consumption { get; private set; }

    public virtual void SetConsumption(TObservableConsumption observableConsumption)
    {
        Consumption = observableConsumption;
    }
    
    [RelayCommand]
    protected abstract void Update();
}