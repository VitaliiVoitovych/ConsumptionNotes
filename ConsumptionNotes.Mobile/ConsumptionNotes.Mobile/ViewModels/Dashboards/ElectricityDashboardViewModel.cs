using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public class ElectricityDashboardViewModel(ElectricityNotesService notesService, FileSystemService fileSystemService)
    : BaseDashboardViewModel<ElectricityConsumption, ElectricityChartService, ElectricityNotesService>(notesService, fileSystemService)
{
    protected override string ExportFileName => "electricity";
    
    public override IAsyncRelayCommand OpenAddingPageCommand => openAddingPageCommand ??= new AsyncRelayCommand(async () =>
    {
        await Shell.Current.GoToAsync($"{nameof(ElectricityAddingPage)}", true);
    });
}