using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Desktop.Commands;
using ConsumptionNotes.Desktop.Extensions;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Desktop.ViewModels.Editing;
using ConsumptionNotes.Desktop.Views.Adding;
using ConsumptionNotes.Desktop.Views.Editing;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public partial class NaturalGasDashboardViewModel
    : BaseDashboardViewModel<NaturalGasConsumption, NaturalGasChartService, NaturalGasNotesService>
{
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand ExportDataCommand { get; }
    public AsyncRelayCommand OpenAddingDialogCommand { get; } =
        new OpenAddingDialogCommand<NaturalGasAddingView, NaturalGasAddingViewModel>();
    
    public NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }
    
    [RelayCommand]
    private async Task OpenEditingDialog(NaturalGasConsumption consumption)
    {
        var view = Ioc.Default.GetRequiredService<NaturalGasEditingView>();
        var viewModel = view.DataContext as NaturalGasEditingViewModel;
        viewModel!.SetConsumption(consumption);
        await view.ShowContentDialog($"Редагування: {consumption.Date:MMMM yyyy}", "Відмінити", "Оновити", ContentDialogButton.Primary, viewModel!.UpdateCommand);
    }
}