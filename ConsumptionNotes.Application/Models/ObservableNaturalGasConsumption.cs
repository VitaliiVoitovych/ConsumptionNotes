namespace ConsumptionNotes.Application.Models;

public class ObservableNaturalGasConsumption(NaturalGasConsumption consumption) 
    : ObservableBaseConsumption<NaturalGasConsumption>(consumption)
{
    public double CubicMeterConsumed
    {
        get => Consumption.CubicMeterConsumed;
        set => SetProperty(Consumption.CubicMeterConsumed, value, Consumption, 
            (c, m) => c.CubicMeterConsumed = m);
    }
}