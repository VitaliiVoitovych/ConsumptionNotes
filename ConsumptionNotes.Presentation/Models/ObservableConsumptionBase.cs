namespace ConsumptionNotes.Presentation.Models;

public abstract class ObservableConsumptionBase<TConsumption>(TConsumption consumption) : ObservableObject
    where TConsumption : ConsumptionBase
{
    public TConsumption Consumption { get; } = consumption;

    public DateOnly Date
    {
        get => Consumption.Date;
        set => SetProperty(Consumption.Date, value, Consumption, 
            (consumption, date) => consumption.Date = date);
    }

    public decimal AmountToPay
    {
        get => Consumption.AmountToPay;
        set => SetProperty(Consumption.AmountToPay, value, Consumption,
            (consumption, amount) => consumption.AmountToPay = amount);
    }
}