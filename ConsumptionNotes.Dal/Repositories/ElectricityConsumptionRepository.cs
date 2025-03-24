using ConsumptionNotes.Dal.Repositories.Base;

namespace ConsumptionNotes.Dal.Repositories;

public class ElectricityConsumptionRepository : RepositoryBase<ElectricityConsumption>
{
    public ElectricityConsumptionRepository(ConsumptionNotesDbContext context) : base(context)
    {
    }
}