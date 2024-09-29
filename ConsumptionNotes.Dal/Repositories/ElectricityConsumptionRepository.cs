using ConsumptionNotes.Dal.Repositories.Base;
using ConsumptionNotes.Domain.Models;

namespace ConsumptionNotes.Dal.Repositories;

public class ElectricityConsumptionRepository : BaseRepository<ElectricityConsumption>
{
    public ElectricityConsumptionRepository(ConsumptionNotesDbContext context) : base(context)
    {
    }
}