using ConsumptionNotes.Dal.Repositories.Base;

namespace ConsumptionNotes.Dal.Repositories;

public class ElectricityConsumptionRepository : BaseRepository<ElectricityConsumption>
{
    public ElectricityConsumptionRepository(ConsumptionNotesDbContext context) : base(context)
    {
    }
}