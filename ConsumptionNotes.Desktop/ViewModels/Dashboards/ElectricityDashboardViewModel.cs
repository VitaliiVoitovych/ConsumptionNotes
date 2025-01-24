using ConsumptionNotes.Application.Models;
using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Desktop.Commands;
using ConsumptionNotes.Desktop.Extensions;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Desktop.ViewModels.Editing;
using ConsumptionNotes.Desktop.Views.Adding;
using ConsumptionNotes.Desktop.Views.Editing;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public class ElectricityDashboardViewModel
    : BaseDashboardViewModel<ElectricityConsumption, ObservableElectricityConsumption,ElectricityChartService, ElectricityNotesService>
{
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand ExportDataCommand { get; }
    public AsyncRelayCommand OpenAddingDialogCommand { get; } =
        new OpenAddingDialogCommand<ElectricityAddingView, ElectricityAddingViewModel>();

    public AsyncRelayCommand<ObservableElectricityConsumption> OpenEditingDialogCommand { get; } =
        new OpenEditingDialogCommand<ElectricityConsumption, ObservableElectricityConsumption, ElectricityEditingView, ElectricityEditingViewModel>();
    
    public ElectricityDashboardViewModel(ElectricityNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }

    /*[RelayCommand]
    private async Task OpenEditingDialog(ObservableElectricityConsumption consumption)
    {
        var view = Ioc.Default.GetRequiredService<ElectricityEditingView>();
        var viewModel = view.DataContext as ElectricityEditingViewModel;
        viewModel!.SetConsumption(consumption);
        await view.ShowContentDialog($"Редагування: {consumption.Date:MMMM yyyy}", "Відмінити", "Оновити", ContentDialogButton.Primary, viewModel!.UpdateCommand);
    }*/
}