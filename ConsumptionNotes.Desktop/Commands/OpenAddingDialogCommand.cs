using ConsumptionNotes.Application.Commands.Base;
using ConsumptionNotes.Application.ViewModels.Adding.Interfaces;
using ConsumptionNotes.Desktop.Extensions;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.Commands;

public class OpenAddingDialogCommand<TAddingView, TAddingViewModel> : AsyncCommandBase
    where TAddingView : UserControl
    where TAddingViewModel : class, IAddingViewModel
{
    public override async Task ExecuteAsync()
    {
        var addingView = Ioc.Default.GetRequiredService<TAddingView>();
        var viewModel = addingView.DataContext as TAddingViewModel;
        await addingView.ShowContentDialog("Новий запис", "Відмінити", "Додати", ContentDialogButton.Primary, viewModel!.AddNoteCommand);
    }
}