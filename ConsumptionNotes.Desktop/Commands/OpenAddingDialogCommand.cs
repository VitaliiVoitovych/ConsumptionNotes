using ConsumptionNotes.Presentation.Commands.Base;

namespace ConsumptionNotes.Desktop.Commands;

public class OpenAddingDialogCommand<TConsumption, TObservableConsumption, TAddingView> : AsyncCommandBase
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
    where TAddingView : ConsumptionAddingView<TConsumption, TObservableConsumption>
{
    public override async Task ExecuteAsync()
    {
        var view = Ioc.Default.GetRequiredService<TAddingView>();
        await view.ShowDialog();
    }
}