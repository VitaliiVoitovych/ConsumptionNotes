﻿using ConsumptionNotes.Application.Services.Charting.Styles;
using ConsumptionNotes.Application.Services.Charting.Utils;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace ConsumptionNotes.Application.Services.Charting;

public abstract class BaseChartService<T>
    where T : BaseConsumption
{
    private readonly ObservableCollection<decimal> _amountsToPayValues = [];
    private readonly ObservableCollection<string> _dateLabels = [];

    public IEnumerable<ISeries> AmountsToPaySeries =>
    [
        ChartUtils.CreateLineSeries(_amountsToPayValues, ChartColors.AmountToPaySeriesColor),
    ];

    public IEnumerable<Axis> AmountToPayYAxes =>
    [
        ChartUtils.CreateValueYAxis(d => d.ToString("f2"))
    ];

    public IEnumerable<Axis> ConsumedYAxes =>
    [
        ChartUtils.CreateValueYAxis(),
    ];
    
    public IEnumerable<Axis> DateXAxes =>
    [
        new Axis
        {
            Labels = _dateLabels,
            MaxLimit = ChartConstants.MaxXAxisLabels,
            LabelsPaint = ChartPaints.AxisLabelsPaint,
        }
    ];

    public virtual void AddValues(T consumption)
    {
        _dateLabels.Add(consumption.Date.ToString(ChartConstants.DateFormat));
        _amountsToPayValues.Add(consumption.AmountToPay);
    }
    
    public virtual void AddValues(int index, T consumption)
    {
        _dateLabels.Insert(index, consumption.Date.ToString(ChartConstants.DateFormat));
        _amountsToPayValues.Insert(index, consumption.AmountToPay);
    }

    public virtual void RemoveValues(int index)
    {
        _dateLabels.RemoveAt(index);
        _amountsToPayValues.RemoveAt(index);
    }

    public virtual void UpdateValues(int index, T consumption)
    {
        _amountsToPayValues[index] = consumption.AmountToPay;
    }
}