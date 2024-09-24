using System.Linq;

namespace ConsumptionNotes.Services.Notes;

public partial class NaturalGasNotesService : BaseNotesService<NaturalGasConsumption, NaturalGasChartService>
{
    [ObservableProperty] private double _averageCubicMeterConsumed;
    
    public NaturalGasNotesService(NaturalGasChartService chartService) : base(chartService)
    {
    }

    protected override void UpdateAverageValues()
    {
        base.UpdateAverageValues();

        AverageCubicMeterConsumed = Consumptions.Count > 0 
            ? Consumptions.Average(e => e.CubicMeterConsumed) 
            : 0.0;
    }
}