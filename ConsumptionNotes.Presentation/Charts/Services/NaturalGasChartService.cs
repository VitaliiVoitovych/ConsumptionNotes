using ConsumptionNotes.Presentation.Charts.Styles;
using ConsumptionNotes.Presentation.Charts.Utils;

namespace ConsumptionNotes.Presentation.Charts.Services;

public class NaturalGasChartService : ConsumptionChartServiceBase<NaturalGasConsumption>
{
    private readonly ObservableCollection<double> _cubicMeterConsumedValues = [];

    public IEnumerable<ISeries<double>> CubicMeterConsumedSeries =>
    [
        LineSeriesUtil.FromCollection(_cubicMeterConsumedValues, Colors.GasSeriesColor)
    ];

    public override void ClearValues()
    {
        base.ClearValues();
        
        _cubicMeterConsumedValues.Clear();
    }

    public override void AddValues(NaturalGasConsumption consumption)
    {
        base.AddValues(consumption);
        
        _cubicMeterConsumedValues.Add(consumption.CubicMeterConsumed);
    }

    public override void InsertValues(int index, NaturalGasConsumption consumption)
    {
        base.InsertValues(index, consumption);
        
        _cubicMeterConsumedValues.Insert(index, consumption.CubicMeterConsumed);
    }

    public override void RemoveValues(int index)
    {
        base.RemoveValues(index);
        
        _cubicMeterConsumedValues.RemoveAt(index);
    }

    public override void UpdateValues(int index, NaturalGasConsumption consumption)
    {
        base.UpdateValues(index, consumption);

        _cubicMeterConsumedValues[index] = consumption.CubicMeterConsumed;
    }
}