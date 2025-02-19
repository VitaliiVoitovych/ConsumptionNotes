using SolidColorPaint =  LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint;
using SKColor = SkiaSharp.SKColor;

namespace ConsumptionNotes.Presentation.Charts.Utils;

public static class LineSeriesUtil
{
    public static LineSeries<TValues> FromCollection<TValues>(ObservableCollection<TValues> collection, SKColor color,
        string? name = null)
    {
        return new LineSeries<TValues>
        {
            Name = name,
            Values = collection,
            Fill = null,
            Stroke = new SolidColorPaint(color) { StrokeThickness = Constants.DefaultStrokeThickness },
            GeometryFill = new SolidColorPaint(color),
            GeometryStroke = new SolidColorPaint(color) { StrokeThickness = Constants.DefaultStrokeThickness},
            GeometrySize = Constants.DefaultGeometrySize
        };
    }
}