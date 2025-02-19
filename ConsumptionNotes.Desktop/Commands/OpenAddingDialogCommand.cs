using ConsumptionNotes.Desktop.ViewModels.Adding.Interfaces;
using ConsumptionNotes.Presentation.Commands.Base;

namespace ConsumptionNotes.Desktop.Commands;

public class OpenAddingDialogCommand<TAddingView, TAddingViewModel> : AsyncCommandBase
    where TAddingView : UserControl
    where TAddingViewModel : class, IAddingViewModel
{
    public override async Task ExecuteAsync()
    {
        var addingView = Ioc.Default.GetRequiredService<TAddingView>();
        var viewModel = (TAddingViewModel)addingView.DataContext!;
        await addingView.ShowContentDialog("Новий запис", "Відмінити", "Додати", ContentDialogButton.Primary, viewModel.AddNoteCommand);
    }
}