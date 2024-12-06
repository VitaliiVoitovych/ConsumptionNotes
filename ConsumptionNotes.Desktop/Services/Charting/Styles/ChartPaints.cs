﻿using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;

namespace ConsumptionNotes.Desktop.Services.Charting.Styles;

public static class ChartPaints
{
    public static readonly SolidColorPaint AxisLabelsPaint = new(ChartColors.AxisLabelsColor);
    public static readonly SolidColorPaint SeparatorPaint = new(ChartColors.SeparatorColor)
    {
        StrokeThickness = ChartConstants.SeparatorStrokeThickness,
        PathEffect = new DashEffect(ChartConstants.SeparatorDashPattern)
    };
    public static readonly SolidColorPaint LegendTextPaint = new(ChartColors.LegendTextColor);
}