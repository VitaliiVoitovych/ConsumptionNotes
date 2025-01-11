using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public class NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileSystemService fileSystemService)
    : BaseDashboardViewModel<NaturalGasConsumption, NaturalGasChartService, NaturalGasNotesService>(notesService, fileSystemService)
{
    protected override string ExportFileName => "naturalgas";
    
    public override IAsyncRelayCommand OpenAddingPageCommand => openAddingPageCommand ??= new AsyncRelayCommand(async () =>
    {
        await Shell.Current.GoToAsync($"{nameof(NaturalAddingGasPage)}", true);
    });
}