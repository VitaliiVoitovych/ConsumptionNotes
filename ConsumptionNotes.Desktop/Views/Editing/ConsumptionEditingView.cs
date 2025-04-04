using ConsumptionNotes.Presentation.ViewModels.Editing;

namespace ConsumptionNotes.Desktop.Views.Editing;

public abstract class ConsumptionEditingView<TConsumption, TObservableConsumption> : UserControl
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
{
    public async Task ShowDialog(TObservableConsumption consumption)
    {
        var viewModel = (ConsumptionEditingViewModelBase<TConsumption, TObservableConsumption>)DataContext!;
        viewModel.SetConsumption(consumption);
        await this.ShowContentDialog(
            $"Редагувати запис:\n{consumption.Date:MMMM yyyy}", 
            "Відмінити", 
            "Оновити", 
            ContentDialogButton.Primary, 
            viewModel.UpdateCommand);
    }
}