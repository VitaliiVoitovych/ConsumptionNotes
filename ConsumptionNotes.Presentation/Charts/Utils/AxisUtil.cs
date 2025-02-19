using ConsumptionNotes.Presentation.Charts.Styles;

namespace ConsumptionNotes.Presentation.Charts.Utils;

public static class AxisUtil
{
    public static Axis LabelerAxis(Func<double, string>? labeler = null)
    {
        return new Axis
        {
            SeparatorsPaint = Paints.SeparatorPaint,
            Labeler = labeler ?? Labelers.Default,
            TextSize = Constants.AxisTextSize,
            LabelsPaint = Paints.AxisLabelsPaint
        };
    }
}