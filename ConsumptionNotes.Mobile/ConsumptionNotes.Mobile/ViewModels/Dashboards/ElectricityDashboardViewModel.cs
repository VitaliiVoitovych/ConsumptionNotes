using ConsumptionNotes.Application.ViewModels;
using ConsumptionNotes.Mobile.Commands;
using ConsumptionNotes.Mobile.Pages.Editing;
using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public partial class ElectricityDashboardViewModel
    : BaseDashboardViewModel<ElectricityConsumption, ElectricityChartService, ElectricityNotesService>
{
    public AsyncRelayCommand OpenAddingPageCommand { get; } = new GoToCommand(nameof(ElectricityAddingPage), true);

    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand ExportDataCommand { get; }
    
    public ElectricityDashboardViewModel(ElectricityNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand(fileSystemService, ImportFromStream);
        ExportDataCommand = new ExportDataCommand(fileSystemService, WriteToFile);
    }

    [RelayCommand]
    private async Task OpenEditingPage(ElectricityConsumption? consumption)
    {
        if (consumption is null) return;

        await Shell.Current.GoToAsync($"{nameof(ElectricityEditingPage)}", true, new Dictionary<string, object>
        {
            { "Consumption", consumption }
        });
    }
}