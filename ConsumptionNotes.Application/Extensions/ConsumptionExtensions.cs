using ConsumptionNotes.Application.Models;

namespace ConsumptionNotes.Application.Extensions;

public static class ConsumptionExtensions
{
    public static TObservableConsumption Convert<TConsumption, TObservableConsumption>(this TConsumption consumption)
        where TConsumption : BaseConsumption
        where TObservableConsumption : ObservableBaseConsumption<TConsumption>
    {
        return (TObservableConsumption)Activator.CreateInstance(typeof(TObservableConsumption), consumption)!;
    }

    public static List<TConsumption> ToConsumptionsList<TConsumption, TObservableConsumption>(
        this ObservableCollection<TObservableConsumption> collection)
        where TConsumption : BaseConsumption
        where TObservableConsumption : ObservableBaseConsumption<TConsumption>
    {
        return collection.Select(observableConsumption => observableConsumption.Consumption).ToList();
    }
}