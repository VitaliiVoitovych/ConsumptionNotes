using ConsumptionNotes.Application.Services.Charting.Styles;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;

namespace ConsumptionNotes.Application.Services.Charting.Utils;

public static class ChartUtils
{
    public static Axis CreateValueYAxis(Func<double, string>? labeler = default)
    {
        return new Axis
        {
            SeparatorsPaint = ChartPaints.SeparatorPaint,
            Labeler = labeler ?? Labelers.Default,
            TextSize = ChartConstants.AxisTextSize,
            LabelsPaint = ChartPaints.AxisLabelsPaint,
        };
    }
    
    public static LineSeries<TValues> CreateLineSeries<TValues>(ObservableCollection<TValues> values, SKColor color, string? name = null)
    {
        return new LineSeries<TValues>
        {
            Name = name,
            Values = values,
            Fill = null,
            Stroke = new SolidColorPaint(color) { StrokeThickness = ChartConstants.DefaultStrokeThickness },
            GeometryFill = new SolidColorPaint(color),
            GeometryStroke = new SolidColorPaint(color) { StrokeThickness = ChartConstants.DefaultStrokeThickness },
            GeometrySize = ChartConstants.DefaultGeometrySize,
        };
    }
}