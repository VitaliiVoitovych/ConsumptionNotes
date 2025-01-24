namespace ConsumptionNotes.Application.Models;

public abstract class ObservableBaseConsumption<TConsumption>(TConsumption consumption) : ObservableObject
    where TConsumption : BaseConsumption
{
    public TConsumption Consumption { get; } = consumption;

    public DateOnly Date
    {
        get => Consumption.Date;
        set => SetProperty(Consumption.Date, value, Consumption, (c, d) => c.Date = d);
    }

    public decimal AmountToPay
    {
        get => Consumption.AmountToPay;
        set => SetProperty(Consumption.AmountToPay, value, Consumption, (c, a) => c.AmountToPay = a);
    }
}