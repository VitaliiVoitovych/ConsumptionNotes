using System.Diagnostics;

namespace ConsumptionNotes.Presentation.ViewModels;

public abstract class MainViewModelBase : ViewModelBase
{
    public ObservableElectricityNotesService ElectricityNotesService { get; }
    public ObservableNaturalGasNotesService NaturalGasNotesService { get; }

    public ElectricityChartService ElectricityChartService => ElectricityNotesService.ChartService;
    public NaturalGasChartService NaturalGasChartService => NaturalGasNotesService.ChartService;
    
    protected MainViewModelBase(
        ObservableElectricityNotesService electricityNotesService, 
        ObservableNaturalGasNotesService naturalGasNotesService)
    {
        ElectricityNotesService = electricityNotesService;
        NaturalGasNotesService = naturalGasNotesService;
        
        Task.Run(async () =>
        {
            var electricityLoad = ElectricityNotesService.LoadDataAsync();
            var naturalGasLoad = NaturalGasNotesService.LoadDataAsync();

            await Task.WhenAll(electricityLoad, naturalGasLoad);
        });
    }
}