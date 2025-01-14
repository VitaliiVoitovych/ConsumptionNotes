using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Desktop.Commands;
using ConsumptionNotes.Desktop.Extensions;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Desktop.Views.Adding;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public partial class ElectricityDashboardViewModel
    : BaseDashboardViewModel<ElectricityConsumption, ElectricityChartService, ElectricityNotesService>
{
    public ImportDataCommand ImportDataCommand { get; }
    public ExportDataCommand ExportDataCommand { get; }
    
    public ElectricityDashboardViewModel(ElectricityNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }
    
    // TODO: Refactore this method
    [RelayCommand]
    private async Task OpenAddingDialog()
    {
        var addingView = Ioc.Default.GetRequiredService<ElectricityAddingView>();
        var viewmodel = addingView.DataContext as ElectricityAddingViewModel;
        await addingView.ShowContentDialog("Новий запис", "Відмінити", "Додати", ContentDialogButton.Primary, viewmodel!.AddNoteCommand.Command);
    }
}