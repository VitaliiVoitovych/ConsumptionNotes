using ConsumptionNotes.Dal.Repositories.Base;
using ConsumptionNotes.Domain.Models;

namespace ConsumptionNotes.Dal.Repositories;

public class NaturalGasConsumptionRepository : BaseRepository<NaturalGasConsumption>
{
    public NaturalGasConsumptionRepository(ConsumptionNotesDbContext context) : base(context)
    {
    }
}