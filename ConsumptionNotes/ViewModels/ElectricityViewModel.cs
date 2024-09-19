namespace ConsumptionNotes.ViewModels;

public class ElectricityViewModel(ElectricityChartService electricityChartService) : ViewModelBase
{
    public ElectricityChartService ElectricityChartService => electricityChartService;
}