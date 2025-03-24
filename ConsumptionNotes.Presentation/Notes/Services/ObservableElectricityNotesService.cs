namespace ConsumptionNotes.Presentation.Notes.Services;

public partial class ObservableElectricityNotesService(
    ElectricityChartService chartService,
    ElectricityNotesService notesService)
    : ObservableConsumptionNotesServiceBase<ElectricityConsumption, ObservableElectricityConsumption, ElectricityChartService,
        ElectricityNotesService>(chartService, notesService)
{
    [ObservableProperty] private double _averageKilowattConsumed;
    
    protected override ObservableElectricityConsumption ToObservableConsumptionObject(ElectricityConsumption consumption)
    {
        return new ObservableElectricityConsumption(consumption);
    }

    protected override void UpdateAverageValues()
    {
        base.UpdateAverageValues();

        AverageKilowattConsumed = NotesService.AverageKilowattConsumed;
    }
}