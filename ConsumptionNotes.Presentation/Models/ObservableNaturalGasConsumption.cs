namespace ConsumptionNotes.Presentation.Models;

public class ObservableNaturalGasConsumption(NaturalGasConsumption consumption)
    : ObservableBaseConsumption<NaturalGasConsumption>(consumption)
{
    public double CubicMeterConsumed
    {
        get => Consumption.CubicMeterConsumed;
        set => SetProperty(Consumption.CubicMeterConsumed, value, Consumption,
            (consumption, cubicMeters) => consumption.CubicMeterConsumed = cubicMeters);
    }
}