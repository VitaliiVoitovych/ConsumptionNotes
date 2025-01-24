using ConsumptionNotes.Application.Commands.Base;
using ConsumptionNotes.Application.Models;
using ConsumptionNotes.Desktop.Extensions;
using ConsumptionNotes.Desktop.ViewModels.Editing;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.Commands;

public class OpenEditingDialogCommand<TConsumption, TObservableConsumption, TEditingView, TEditingViewModel> : AsyncCommandBase<TObservableConsumption>
    where TConsumption : BaseConsumption
    where TObservableConsumption : ObservableBaseConsumption<TConsumption>
    where TEditingView : UserControl
    where TEditingViewModel : BaseEditingViewModel<TConsumption, TObservableConsumption>
{
    public override async Task ExecuteAsync(TObservableConsumption? obj)
    {
        var view = Ioc.Default.GetRequiredService<TEditingView>();
        var viewModel = view.DataContext as TEditingViewModel;
        viewModel!.SetConsumption(obj!);
        await view.ShowContentDialog($"Редагування: {obj!.Date:MMMM yyyy}", "Відмінити", "Оновити", ContentDialogButton.Primary, viewModel!.UpdateCommand);
    }
}