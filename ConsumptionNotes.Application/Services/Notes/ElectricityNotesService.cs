using ConsumptionNotes.Application.Models;
using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Dal.Repositories;

namespace ConsumptionNotes.Application.Services.Notes;

public partial class ElectricityNotesService
    : BaseNotesService<ElectricityConsumption, ObservableElectricityConsumption, ElectricityChartService, ElectricityConsumptionRepository>
{
    [ObservableProperty] private double _averageKilowattConsumed;
    
    public ElectricityNotesService(ElectricityChartService chartService, ElectricityConsumptionRepository repository) 
        : base(chartService, repository)
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