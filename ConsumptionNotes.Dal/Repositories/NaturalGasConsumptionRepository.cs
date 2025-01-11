using ConsumptionNotes.Dal.Repositories.Base;

namespace ConsumptionNotes.Dal.Repositories;

public class NaturalGasConsumptionRepository : BaseRepository<NaturalGasConsumption>
{
    public NaturalGasConsumptionRepository(ConsumptionNotesDbContext context) : base(context)
    {
    }
}