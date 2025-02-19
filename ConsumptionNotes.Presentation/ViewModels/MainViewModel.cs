namespace ConsumptionNotes.Presentation.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ObservableElectricityNotesService ElectricityNotesService { get; }
    public ObservableNaturalGasNotesService NaturalGasNotesService { get; }

    public ElectricityChartService ElectricityChartService => ElectricityNotesService.ChartService;
    public NaturalGasChartService NaturalGasChartService => NaturalGasNotesService.ChartService;
    
    public MainViewModel(
        ObservableElectricityNotesService electricityNotesService, 
        ObservableNaturalGasNotesService naturalGasNotesService)
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