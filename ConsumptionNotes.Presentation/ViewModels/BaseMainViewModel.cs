namespace ConsumptionNotes.Presentation.ViewModels;

public abstract class BaseMainViewModel : ViewModelBase
{
    public ObservableElectricityNotesService ElectricityNotesService { get; }
    public ObservableNaturalGasNotesService NaturalGasNotesService { get; }

    public ElectricityChartService ElectricityChartService => ElectricityNotesService.ChartService;
    public NaturalGasChartService NaturalGasChartService => NaturalGasNotesService.ChartService;
    
    protected BaseMainViewModel(
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