using ConsumptionNotes.Presentation.ViewModels.Dashboards;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public partial class ElectricityDashboardViewModel
    : DashboardViewModelBase<ElectricityConsumption, ObservableElectricityConsumption, ElectricityChartService, ObservableElectricityNotesService>
{
    public AsyncRelayCommand ImportDataCommand { get; }
    public AsyncRelayCommand<IEnumerable<ElectricityConsumption>> ExportDataCommand { get; }

    public AsyncRelayCommand OpenAddingDialogCommand { get; } =
        new OpenAddingDialogCommand<ElectricityAddingView, ElectricityAddingViewModel>();
    
    public ElectricityDashboardViewModel(ObservableElectricityNotesService notesService, FileSystemService fileSystemService)
        : base(notesService)
    {
        ImportDataCommand = new ImportDataCommand<ElectricityConsumption, ObservableElectricityConsumption>(fileSystemService, NotesService);
        ExportDataCommand = new ExportDataCommand<ElectricityConsumption>(fileSystemService, ExportFilename);
    }
    
    [RelayCommand]
    private async Task OpenEditingDialog(ObservableElectricityConsumption consumption)
    {
        var view = Ioc.Default.GetRequiredService<ElectricityEditingView>();
        var viewModel = view.DataContext as ElectricityEditingViewModel;
        viewModel!.SetConsumption(consumption);
        await view.ShowContentDialog($"Редагувати запис:\n{consumption.Date:MMMM yyyy}", "Відмінити", "Оновити", ContentDialogButton.Primary, viewModel.UpdateCommand);
    }
}