﻿using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.Measure;

namespace ConsumptionNotes.Mobile.Views;

public partial class ChartWidget : ContentView
{
    public static readonly BindableProperty TextProperty =
		BindableProperty.Create(nameof(Text), typeof(string), typeof(ChartWidget), default);

    public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

    public static readonly BindableProperty AverageValueProperty =
        BindableProperty.Create(nameof(AverageValue), typeof(string), typeof(ChartWidget), default);

    public string AverageValue
    {
        get => (string)GetValue(AverageValueProperty);
        set => SetValue(AverageValueProperty, value);
    }

    public static readonly BindableProperty SeriesProperty =
        BindableProperty.Create(nameof(Series), typeof(IEnumerable<ISeries>), typeof(ChartWidget), default);

    public IEnumerable<ISeries> Series
	{
		get => (IEnumerable<ISeries>)GetValue(SeriesProperty);
        set => SetValue(SeriesProperty, value);
	}

    public static readonly BindableProperty XAxesProperty =
        BindableProperty.Create(nameof(XAxes), typeof(IEnumerable<ICartesianAxis>), typeof(ChartWidget), default);

    public IEnumerable<ICartesianAxis> XAxes
	{
		get => (IEnumerable<ICartesianAxis>)GetValue(XAxesProperty);
		set => SetValue(XAxesProperty, value);
	}

	public static readonly BindableProperty YAxesProperty =
		BindableProperty.Create(nameof(YAxes), typeof(IEnumerable<ICartesianAxis>), typeof(ChartWidget), default);

	public IEnumerable<ICartesianAxis> YAxes
	{
		get => (IEnumerable<ICartesianAxis>)GetValue(YAxesProperty);
		set => SetValue(YAxesProperty, value);
    }

	public static readonly BindableProperty LegendPositionProperty =
		BindableProperty.Create(nameof(LegendPosition), typeof(LegendPosition), typeof(ChartWidget), default);

	public LegendPosition LegendPosition
	{
		get => (LegendPosition)GetValue(LegendPositionProperty);
		set => SetValue(LegendPositionProperty, value);
	}
    
    public ChartWidget()
    {
        InitializeComponent();
    }

    public void UpdateChart() => Chart.CoreChart.Update();
}