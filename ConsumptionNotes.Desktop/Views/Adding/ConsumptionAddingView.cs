using ConsumptionNotes.Presentation.ViewModels.Adding;

namespace ConsumptionNotes.Desktop.Views.Adding;

public abstract class ConsumptionAddingView<TConsumption, TObservableConsumption> : UserControl
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
{
    public async Task ShowDialog()
    {
        var viewModel = (ConsumptionAddingViewModelBase<TConsumption, TObservableConsumption>)DataContext!;
        AsyncRelayCommand addNoteCommand = new AddNoteCommand(viewModel.AddNote);
        await this.ShowContentDialog(
            "Новий запис", 
            "Відмінити", 
            "Додати", 
            ContentDialogButton.Primary, 
            addNoteCommand);
    }
}