using System.Linq;

namespace ConsumptionNotes.Services.Notes;

public partial class ElectricityNotesService : BaseNotesService<ElectricityConsumption, ElectricityChartService>
{
    [ObservableProperty] private double _averageKilowattConsumed;
    
    public ElectricityNotesService(ElectricityChartService chartService) 
        : base(chartService)
    {
        
    }

    protected override void UpdateAverageValues()
    {
        base.UpdateAverageValues();
        
        AverageKilowattConsumed = Consumptions.Count > 0
            ? Consumptions.Average(e => e.DayKilowattConsumed + e.NightKilowattConsumed)
            : 0.0;
    }
}