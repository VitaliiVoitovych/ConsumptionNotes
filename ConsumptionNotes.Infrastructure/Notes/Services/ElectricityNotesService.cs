using ConsumptionNotes.Dal.Repositories;

namespace ConsumptionNotes.Infrastructure.Notes.Services;

public class ElectricityNotesService(ElectricityConsumptionRepository repository) 
    : NotesServiceBase<ElectricityConsumption, ElectricityConsumptionRepository>(repository)
{
    public double AverageKilowattConsumed { get; private set; }

    protected override void UpdateAverageValues()
    {
        base.UpdateAverageValues();
        
        AverageKilowattConsumed = Consumptions.Count > 0
            ? Consumptions.Average(e => e.DayKilowattConsumed + e.NightKilowattConsumed)
            : 0.0;
    }
}