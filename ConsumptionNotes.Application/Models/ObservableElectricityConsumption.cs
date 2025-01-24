namespace ConsumptionNotes.Application.Models;

public class ObservableElectricityConsumption(ElectricityConsumption consumption) 
    : ObservableBaseConsumption<ElectricityConsumption>(consumption)
{
    public int DayKilowattConsumed
    {
        get => Consumption.DayKilowattConsumed;
        set => SetProperty(Consumption.DayKilowattConsumed, value, Consumption, 
            (c, d) => c.DayKilowattConsumed = d);
    }
    
    public int NightKilowattConsumed
    {
        get => Consumption.NightKilowattConsumed;
        set => SetProperty(Consumption.NightKilowattConsumed, value, Consumption, 
            (c, n) => c.NightKilowattConsumed = n);
    }
}