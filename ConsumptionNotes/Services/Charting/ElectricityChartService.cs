using LiveChartsCore;
using SkiaSharp;

namespace ConsumptionNotes.Services.Charting;

public class ElectricityChartService : BaseChartService<ElectricityConsumption>
{
    private readonly SKColor _daySeriesColor = SKColor.Parse("#e2e38b");
    private readonly SKColor _nightSeriesColor = SKColor.Parse("#29297d");
    
    private readonly ObservableCollection<int> _dayKilowattConsumed = [];
    private readonly ObservableCollection<int> _nightKilowattConsumed = [];

    public IEnumerable<ISeries> KilowattConsumedSeries =>
    [
        CreateLineSeries("День", _dayKilowattConsumed, _daySeriesColor),
        CreateLineSeries("Ніч", _nightKilowattConsumed, _nightSeriesColor),
    ];
    
    public override void AddValues(ElectricityConsumption consumption)
    {
        base.AddValues(consumption);
        _dayKilowattConsumed.Add(consumption.DayKilowattConsumed);
        _nightKilowattConsumed.Add(consumption.NightKilowattConsumed);
    }
}