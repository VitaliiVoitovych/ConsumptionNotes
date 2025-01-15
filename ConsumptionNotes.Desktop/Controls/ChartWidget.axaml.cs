using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.Measure;

namespace ConsumptionNotes.Desktop.Controls;

public partial class ChartWidget : UserControl
{
    public static readonly StyledProperty<string?> TextProperty = AvaloniaProperty.Register<ChartWidget, string?>(
        nameof(Text));

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly StyledProperty<string> AverageValueProperty = AvaloniaProperty.Register<ChartWidget, string>(
        nameof(AverageValue));

    public string AverageValue
    {
        get => GetValue(AverageValueProperty);
        set => SetValue(AverageValueProperty, value);
    }

    public static readonly StyledProperty<IEnumerable<ISeries>> SeriesProperty = AvaloniaProperty.Register<ChartWidget, IEnumerable<ISeries>>(
        nameof(Series));

    public IEnumerable<ISeries> Series
    {
        get => GetValue(SeriesProperty);
        set => SetValue(SeriesProperty, value);
    }

    public static readonly StyledProperty<IEnumerable<ICartesianAxis>> XAxesProperty = AvaloniaProperty.Register<ChartWidget, IEnumerable<ICartesianAxis>>(
        nameof(XAxes));

    public IEnumerable<ICartesianAxis> XAxes
    {
        get => GetValue(XAxesProperty);
        set => SetValue(XAxesProperty, value);
    }

    public static readonly StyledProperty<IEnumerable<ICartesianAxis>> YAxesProperty = AvaloniaProperty.Register<ChartWidget, IEnumerable<ICartesianAxis>>(
        nameof(YAxes));

    public IEnumerable<ICartesianAxis> YAxes
    {
        get => GetValue(YAxesProperty);
        set => SetValue(YAxesProperty, value);
    }

    public static readonly StyledProperty<LegendPosition> LegendPositionProperty = AvaloniaProperty.Register<ChartWidget, LegendPosition>(
        nameof(LegendPosition));

    public LegendPosition LegendPosition
    {
        get => GetValue(LegendPositionProperty);
        set => SetValue(LegendPositionProperty, value);
    }
    
    public ChartWidget()
    {
        InitializeComponent();
    }
}