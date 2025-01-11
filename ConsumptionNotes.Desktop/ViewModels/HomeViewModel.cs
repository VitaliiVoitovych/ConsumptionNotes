namespace ConsumptionNotes.Desktop.ViewModels;

public class HomeViewModel: ViewModelBase
{
    public ElectricityNotesService ElectricityNotesService { get; }
    public NaturalGasNotesService NaturalGasNotesService { get; }

    public ElectricityChartService ElectricityChartService => ElectricityNotesService.ChartService;
    public NaturalGasChartService NaturalGasChartService => NaturalGasNotesService.ChartService;

    public HomeViewModel(ElectricityNotesService electricityNotesService,
        NaturalGasNotesService naturalGasNotesService)
    {
        ElectricityNotesService = electricityNotesService;
        NaturalGasNotesService = naturalGasNotesService;

        Task.Run(async () =>
        {
            await ElectricityNotesService.LoadDataAsync();
            await NaturalGasNotesService.LoadDataAsync();
        });
    }
}