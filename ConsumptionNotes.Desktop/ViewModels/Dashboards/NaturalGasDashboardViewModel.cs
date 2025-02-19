using ConsumptionNotes.Presentation.ViewModels.Dashboards;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public partial class NaturalGasDashboardViewModel
    : DashboardViewModelBase<NaturalGasConsumption, ObservableNaturalGasConsumption, NaturalGasChartService, ObservableNaturalGasNotesService>
{
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand<IEnumerable<NaturalGasConsumption>> ExportDataCommand { get; }

    public AsyncRelayCommand OpenAddingDialogCommand { get; } =
        new OpenAddingDialogCommand<NaturalGasAddingView, NaturalGasAddingViewModel>();
    
    public NaturalGasDashboardViewModel(ObservableNaturalGasNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand<NaturalGasConsumption,ObservableNaturalGasConsumption>(fileSystemService, NotesService);
        ExportDataCommand = new ExportDataCommand<NaturalGasConsumption>(fileSystemService, ExportFilename);
    }
    
    [RelayCommand]
    private async Task OpenEditingDialog(ObservableNaturalGasConsumption consumption)
    {
        var view = Ioc.Default.GetRequiredService<NaturalGasEditingView>();
        var viewModel = view.DataContext as NaturalGasEditingViewModel;
        viewModel!.SetConsumption(consumption);
        await view.ShowContentDialog($"Редагувати запис:\n{consumption.Date:MMMM yyyy}", "Відмінити", "Оновити", ContentDialogButton.Primary, viewModel!.UpdateCommand);
    }
}