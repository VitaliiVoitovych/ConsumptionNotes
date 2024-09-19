namespace ConsumptionNotes.ViewModels;

public class NaturalGasViewModel(NaturalGasChartService naturalGasChartService) : ViewModelBase
{
    public NaturalGasChartService NaturalGasChartService => naturalGasChartService;
}