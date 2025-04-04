using ConsumptionNotes.Presentation.Commands.Base;

namespace ConsumptionNotes.Desktop.Commands;

public class OpenEditingDialogCommand<TConsumption, TObservableConsumption, TEditingView> : AsyncCommandBase<TObservableConsumption>
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
    where TEditingView : ConsumptionEditingView<TConsumption, TObservableConsumption>
{
    public override async Task ExecuteAsync(TObservableConsumption? consumption)
    {
        if (consumption is null) return;
        var view = Ioc.Default.GetRequiredService<TEditingView>();
        await view.ShowDialog(consumption);
    }
}