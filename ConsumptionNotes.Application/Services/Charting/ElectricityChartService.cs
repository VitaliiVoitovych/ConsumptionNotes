﻿using ConsumptionNotes.Application.Services.Charting.Styles;
using ConsumptionNotes.Application.Services.Charting.Utils;
using LiveChartsCore;

namespace ConsumptionNotes.Application.Services.Charting;

public class ElectricityChartService : BaseChartService<ElectricityConsumption>
{
    private readonly ObservableCollection<int> _dayKilowattConsumed = [];
    private readonly ObservableCollection<int> _nightKilowattConsumed = [];

    public IEnumerable<ISeries> KilowattConsumedSeries =>
    [
        ChartUtils.CreateLineSeries(_dayKilowattConsumed, ChartColors.DaySeriesColor, "День"),
        ChartUtils.CreateLineSeries(_nightKilowattConsumed, ChartColors.NightSeriesColor, "Ніч"),
    ];

    public override void AddValues(ElectricityConsumption consumption)
    {
        base.AddValues(consumption);
        _dayKilowattConsumed.Add(consumption.DayKilowattConsumed);
        _nightKilowattConsumed.Add(consumption.NightKilowattConsumed);
    }

    public override void AddValues(int index, ElectricityConsumption consumption)
    {
        base.AddValues(index, consumption);
        _dayKilowattConsumed.Insert(index, consumption.DayKilowattConsumed);
        _nightKilowattConsumed.Insert(index, consumption.NightKilowattConsumed);
    }

    public override void RemoveValues(int index)
    {
        base.RemoveValues(index);
        _dayKilowattConsumed.RemoveAt(index);
        _nightKilowattConsumed.RemoveAt(index);
    }

    public override void UpdateValues(int index, ElectricityConsumption consumption)
    {
        base.UpdateValues(index, consumption);
        _dayKilowattConsumed[index] = consumption.DayKilowattConsumed;
        _nightKilowattConsumed[index] = consumption.NightKilowattConsumed;
    }
}