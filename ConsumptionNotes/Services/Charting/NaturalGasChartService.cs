using LiveChartsCore;
using SkiaSharp;

namespace ConsumptionNotes.Services.Charting;

public class NaturalGasChartService : BaseChartService<NaturalGasConsumption>
{
    private readonly SKColor _gasConsumedSeriesColor = SKColor.Parse("#367fd7");
    
    private readonly ObservableCollection<int> _cubicMeterConsumed = [];

    public IEnumerable<ISeries> CubicMeterConsumedSeries =>
    [
        CreateLineSeries(null, _cubicMeterConsumed, _gasConsumedSeriesColor),
    ];
    
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