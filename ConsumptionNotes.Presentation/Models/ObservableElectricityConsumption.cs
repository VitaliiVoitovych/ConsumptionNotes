namespace ConsumptionNotes.Presentation.Models;

public class ObservableElectricityConsumption(ElectricityConsumption consumption) 
    : ObservableConsumptionBase<ElectricityConsumption>(consumption)
{
    public int DayKilowattConsumed
    {
        get => Consumption.DayKilowattConsumed;
        set => SetProperty(Consumption.DayKilowattConsumed, value, Consumption,
            (consumption, dayKilowattConsumed) => consumption.DayKilowattConsumed = dayKilowattConsumed);
    }

    public int NightKilowattConsumed
    {
        get => Consumption.NightKilowattConsumed;
        set => SetProperty(Consumption.NightKilowattConsumed, value, Consumption,
            (consumption, nightKilowattConsumed) => consumption.NightKilowattConsumed = nightKilowattConsumed);
    }
}