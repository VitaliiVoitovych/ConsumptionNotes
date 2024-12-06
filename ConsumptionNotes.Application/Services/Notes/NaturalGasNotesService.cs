using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Dal.Repositories;

namespace ConsumptionNotes.Application.Services.Notes;

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