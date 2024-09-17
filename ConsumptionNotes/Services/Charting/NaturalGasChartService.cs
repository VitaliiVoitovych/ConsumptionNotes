using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
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
    
    public override void AddValues(NaturalGasConsumption consumption)
    {
        base.AddValues(consumption);
        _cubicMeterConsumed.Add(consumption.CubicMeterConsumed);
    }
}