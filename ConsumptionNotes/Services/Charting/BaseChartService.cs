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
            LabelsPaint = new SolidColorPaint(SKColor.Parse("#95b5cf")),
        }
    ];

    public SolidColorPaint LegendTextPaint => new SolidColorPaint(SKColor.Parse("#abb0b3"));
    
    private static Axis CreateValueYAxis(Func<double, string>? labeler = default)
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
            LabelsPaint = new SolidColorPaint(SKColor.Parse("#95b5cf"))
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
    
    public virtual void AddValues(T consumption)
    {
        _dateLabels.Add(consumption.Date.ToString("MMM yyyy"));
        _amountsToPayValues.Add(consumption.AmountToPay);
    }
}