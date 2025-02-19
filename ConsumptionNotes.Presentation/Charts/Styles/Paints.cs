using SolidColorPaint = LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint;
using DashEffect =  LiveChartsCore.SkiaSharpView.Painting.Effects.DashEffect;

namespace ConsumptionNotes.Presentation.Charts.Styles;

public static class Paints
{
    public static readonly SolidColorPaint AxisLabelsPaint = new(Colors.AxisLabelsColor);
    public static readonly SolidColorPaint SeparatorPaint = new(Colors.SeparatorColor)
    {
        StrokeThickness = Constants.SeparatorStrokeThickness,
        PathEffect = new DashEffect(Constants.SeparatorDashPattern)
    };
    public static readonly SolidColorPaint LegendTextPaint = new(Colors.LegendTextColor);
    
    // Tooltip paints
    public static readonly SolidColorPaint TooltipTextPaint = new(Colors.TooltipTextColor);
    public static readonly SolidColorPaint TooltipBackgroundPaint = new(Colors.TooltipBackgroundColor);
}