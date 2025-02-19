namespace ConsumptionNotes.Presentation.Notes.Services;

public partial class ObservableNaturalGasNotesService(
    NaturalGasChartService chartService,
    NaturalGasNotesService notesService)
    : ObservableNotesServiceBase<NaturalGasConsumption, ObservableNaturalGasConsumption, NaturalGasChartService,
        NaturalGasNotesService>(chartService, notesService)
{
    [ObservableProperty] private double _averageCubicMeterConsumed;
    
    protected override ObservableNaturalGasConsumption ToObservableConsumptionObject(NaturalGasConsumption consumption)
    {
        return new ObservableNaturalGasConsumption(consumption);
    }

    protected override void UpdateAverageValues()
    {
        base.UpdateAverageValues();

        AverageCubicMeterConsumed = NotesService.AverageCubicMeterConsumed;
    }
}