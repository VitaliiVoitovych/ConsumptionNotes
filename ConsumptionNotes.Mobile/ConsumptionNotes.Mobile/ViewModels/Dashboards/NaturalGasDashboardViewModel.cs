using ConsumptionNotes.Application.Models;
using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Mobile.Commands;
using ConsumptionNotes.Mobile.Pages.Editing;
using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public partial class NaturalGasDashboardViewModel
    : BaseDashboardViewModel<NaturalGasConsumption, ObservableNaturalGasConsumption, NaturalGasChartService, NaturalGasNotesService>
{
    public AsyncRelayCommand OpenAddingPageCommand { get; } = new GoToCommand(nameof(NaturalGasAddingPage), true);

    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand ExportDataCommand { get; }
    
    public NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }
    
    [RelayCommand]
    private async Task OpenEditingPage(ObservableNaturalGasConsumption? consumption)
    {
        if (consumption is null) return;

        await Shell.Current.GoToAsync($"{nameof(NaturalGasEditingPage)}?id={consumption.Date}", true, new Dictionary<string, object>
        {
            {"Consumption", consumption}
        });
    }
}