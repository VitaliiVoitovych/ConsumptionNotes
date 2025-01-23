using ConsumptionNotes.Application.Services.Charting.Styles;
using ConsumptionNotes.Application.Services.Charting.Utils;
using LiveChartsCore;

namespace ConsumptionNotes.Application.Services.Charting;

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

    public override void UpdateValues(int index, NaturalGasConsumption consumption)
    {
        base.UpdateValues(index, consumption);
        _cubicMeterConsumed[index] = consumption.CubicMeterConsumed;
    }
}