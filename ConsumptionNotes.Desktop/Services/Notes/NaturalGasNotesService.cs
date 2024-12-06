using System.Linq;
using ConsumptionNotes.Desktop.Services.Charting;

namespace ConsumptionNotes.Desktop.Services.Notes;

public partial class NaturalGasNotesService 
    : BaseNotesService<NaturalGasConsumption, NaturalGasChartService, NaturalGasConsumptionRepository>
{
    [ObservableProperty] private double _averageCubicMeterConsumed;
    
    public NaturalGasNotesService(NaturalGasChartService chartService, NaturalGasConsumptionRepository repository) 
        : base(chartService, repository)
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