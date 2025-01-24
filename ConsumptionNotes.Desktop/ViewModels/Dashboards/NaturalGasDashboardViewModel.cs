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

public partial class NaturalGasDashboardViewModel
    : BaseDashboardViewModel<NaturalGasConsumption, ObservableNaturalGasConsumption, NaturalGasChartService, NaturalGasNotesService>
{
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand ExportDataCommand { get; }
    public AsyncRelayCommand OpenAddingDialogCommand { get; } =
        new OpenAddingDialogCommand<NaturalGasAddingView, NaturalGasAddingViewModel>();

    public AsyncRelayCommand<ObservableNaturalGasConsumption> OpenEditingDialogCommand { get; } =
        new OpenEditingDialogCommand<NaturalGasConsumption, ObservableNaturalGasConsumption, NaturalGasEditingView,
            NaturalGasEditingViewModel>();
    
    public NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }
}