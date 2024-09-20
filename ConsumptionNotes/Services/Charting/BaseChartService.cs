using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;

namespace ConsumptionNotes.Services.Charting;

public abstract class BaseChartService<T>
    where T: BaseConsumption
{
    private readonly SKColor _amountToPaySeriesColor = SKColor.Parse("#256F33");
    private readonly SolidColorPaint _axisLabelsPaint = new(SKColor.Parse("#95b5cf"));
    
    private readonly ObservableCollection<decimal> _amountsToPayValues = [];
    private readonly ObservableCollection<string> _dateLabels = [];

    public IEnumerable<ISeries> AmountsToPaySeries =>
    [
        CreateLineSeries(null, _amountsToPayValues, _amountToPaySeriesColor),
    ];

    public IEnumerable<Axis> AmountToPayYAxes =>
    [
        CreateValueYAxis(d => d.ToString("f2"))
    ];

    public IEnumerable<Axis> ConsumedYAxed =>
    [
        CreateValueYAxis(),
    ];
    
    public IEnumerable<Axis> DateXAxes =>
    [
        new Axis
        {
            Labels = _dateLabels,
            MaxLimit = 12,
            LabelsPaint = _axisLabelsPaint,
        }
    ];

    public SolidColorPaint LegendTextPaint => new SolidColorPaint(SKColor.Parse("#e9ecef"));
    
    private Axis CreateValueYAxis(Func<double, string>? labeler = default)
    {
        return new Axis
        {
            SeparatorsPaint = new SolidColorPaint(SKColors.LightGray)
            {
                StrokeThickness = 0.5f,
                PathEffect = new DashEffect([4f, 4f])
            },
            Labeler = labeler ?? Labelers.Default,
            TextSize = 15,
            LabelsPaint = _axisLabelsPaint,
        };
    }

    protected LineSeries<TValues> CreateLineSeries<TValues>(string? name, ObservableCollection<TValues> values, SKColor color)
    {
        return new LineSeries<TValues>
        {
            Name = name,
            Values = values,
            Fill = null,
            Stroke = new SolidColorPaint(color) { StrokeThickness = 3 },
            GeometryFill = new SolidColorPaint(color),
            GeometryStroke = new SolidColorPaint(color) { StrokeThickness = 3 },
            GeometrySize = 5,
        };
    }
    
    public virtual void AddValues(int index, T consumption)
    {
        _dateLabels.Insert(index, consumption.Date.ToString("MMM yyyy"));
        _amountsToPayValues.Insert(index, consumption.AmountToPay);
    }

    public virtual void RemoveValues(int index)
    {
        _dateLabels.RemoveAt(index);
        _amountsToPayValues.RemoveAt(index);
    }
}