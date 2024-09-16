using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;

namespace ConsumptionNotes.Services.Charting;

public abstract class BaseChartService
{
    private readonly SKColor _amountToPayColor = SKColor.Parse("#256F33");
    
    protected readonly ObservableCollection<decimal> _amountsToPayValues = [];
    protected readonly ObservableCollection<string> _dateLabels = [];

    public IEnumerable<ISeries> AmountsToPaySeries =>
    [
        new LineSeries<decimal>
        {
            Values = _amountsToPayValues,
            Fill = null,
            Stroke = new SolidColorPaint(_amountToPayColor) { StrokeThickness = 3},
            GeometryFill = new SolidColorPaint(_amountToPayColor),
            GeometryStroke = new SolidColorPaint(_amountToPayColor) {StrokeThickness = 2},
            GeometrySize = 5,
        }
    ];

    public IEnumerable<Axis> AmountToPayYAxes =>
    [
        new Axis
        {
            SeparatorsPaint = new SolidColorPaint(SKColors.LightGray)
            {
                StrokeThickness = 0.5f,
                PathEffect = new DashEffect([4f, 4f])
            },
            Labeler = d => d.ToString("f2"),
            TextSize = 15,
            LabelsPaint = new SolidColorPaint(SKColor.Parse("#95b5cf"))
        }
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
}