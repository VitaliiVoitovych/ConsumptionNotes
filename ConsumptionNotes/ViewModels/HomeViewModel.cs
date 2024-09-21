namespace ConsumptionNotes.ViewModels;

public class HomeViewModel(
    ElectricityNotesService electricityNotesService,
    NaturalGasNotesService naturalGasNotesService
    ) : ViewModelBase
{
    public ElectricityNotesService ElectricityNotesService => electricityNotesService;
    public NaturalGasNotesService NaturalGasNotesService => naturalGasNotesService;

    public ElectricityChartService ElectricityChartService => ElectricityNotesService.ChartService;
    public NaturalGasChartService NaturalGasChartService => NaturalGasNotesService.ChartService;
}