using ConsumptionNotes.Desktop.Services.Charting.Styles;
using ConsumptionNotes.Desktop.Services.Charting.Utils;

namespace ConsumptionNotes.Desktop.Services.Charting;

public class NaturalGasChartService : BaseChartService<NaturalGasConsumption>
{
    private readonly ObservableCollection<double> _cubicMeterConsumed = [];

    public IEnumerable<ISeries> CubicMeterConsumedSeries =>
    [
        ChartUtils.CreateLineSeries(_cubicMeterConsumed, ChartColors.GasSeriesColor),
    ];

    public override void AddValues(NaturalGasConsumption consumption)
    {
        base.AddValues(consumption);
        _cubicMeterConsumed.Add(consumption.CubicMeterConsumed);
    }

    public override void AddValues(int index, NaturalGasConsumption consumption)
    {
        base.AddValues(index, consumption);
        _cubicMeterConsumed.Insert(index, consumption.CubicMeterConsumed);
    }

    public override void RemoveValues(int index)
    {
        base.RemoveValues(index);
        _cubicMeterConsumed.RemoveAt(index);
    }
}