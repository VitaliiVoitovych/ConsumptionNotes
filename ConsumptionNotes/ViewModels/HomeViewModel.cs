using System;

namespace ConsumptionNotes.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public ElectricityChartService ElectricityChartService { get; }
    public NaturalGasChartService NaturalGasChartService { get; }
    
    public HomeViewModel(ElectricityChartService electricityChartService, NaturalGasChartService naturalGasChartService)
    {
        ElectricityChartService = electricityChartService;
        NaturalGasChartService = naturalGasChartService;

        ElectricityChartService.AddValues(new ElectricityConsumption(DateOnly.FromDateTime(DateTime.Now), 23, 23, 231));
        NaturalGasChartService.AddValues(new NaturalGasConsumption(DateOnly.FromDateTime(DateTime.Now), 34, 344));
        ElectricityChartService.AddValues(new ElectricityConsumption(DateOnly.FromDateTime(DateTime.Now), 23,23, 231));
        NaturalGasChartService.AddValues(new NaturalGasConsumption(DateOnly.FromDateTime(DateTime.Now), 34, 344));
    }
}