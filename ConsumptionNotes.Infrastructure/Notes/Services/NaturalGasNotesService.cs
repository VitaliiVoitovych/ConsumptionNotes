using ConsumptionNotes.Dal.Repositories;

namespace ConsumptionNotes.Infrastructure.Notes.Services;

public class NaturalGasNotesService(NaturalGasConsumptionRepository repository)
    : ConsumptionNotesServiceBase<NaturalGasConsumption, NaturalGasConsumptionRepository>(repository)
{
    public double AverageCubicMeterConsumed { get; private set; }
    
    protected override void UpdateAverageValues()
    {
        base.UpdateAverageValues();

        AverageCubicMeterConsumed = Consumptions.Count > 0 
            ? Consumptions.Average(e => e.CubicMeterConsumed) 
            : 0.0;
    }
}