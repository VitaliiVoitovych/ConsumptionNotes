using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Desktop.Commands;
using ConsumptionNotes.Desktop.Extensions;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Desktop.Views.Adding;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public partial class NaturalGasDashboardViewModel
    : BaseDashboardViewModel<NaturalGasConsumption, NaturalGasChartService, NaturalGasNotesService>
{
    public ImportDataCommand ImportDataCommand { get; }
    public ExportDataCommand ExportDataCommand { get; }
    
    public NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }
    
    [RelayCommand]
    private async Task OpenAddingDialog()
    {
        var addingView = Ioc.Default.GetRequiredService<NaturalGasAddingView>();
        var viewmodel = addingView.DataContext as NaturalGasAddingViewModel;
        await addingView.ShowContentDialog("Новий запис", "Відмінити", "Додати", ContentDialogButton.Primary, viewmodel!.AddNoteCommand.Command);
    }
}