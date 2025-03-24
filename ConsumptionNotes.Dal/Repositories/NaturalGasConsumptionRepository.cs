using ConsumptionNotes.Dal.Repositories.Base;

namespace ConsumptionNotes.Dal.Repositories;

public class NaturalGasConsumptionRepository : RepositoryBase<NaturalGasConsumption>
{
    public NaturalGasConsumptionRepository(ConsumptionNotesDbContext context) : base(context)
    {
    }
}