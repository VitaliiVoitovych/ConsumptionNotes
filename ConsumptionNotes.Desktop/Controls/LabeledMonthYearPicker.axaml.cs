using Avalonia.Layout;

namespace ConsumptionNotes.Desktop.Controls;

public partial class LabeledMonthYearPicker : UserControl
{
    public static readonly StyledProperty<string?> TextProperty = AvaloniaProperty.Register<LabeledMonthYearPicker, string?>(
        nameof(Text));

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly StyledProperty<DateTimeOffset?> SelectedDateProperty = AvaloniaProperty.Register<LabeledMonthYearPicker, DateTimeOffset?>(
        nameof(SelectedDate));

    public DateTimeOffset? SelectedDate
    {
        get => GetValue(SelectedDateProperty);
        set => SetValue(SelectedDateProperty, value);
    }

    public static readonly StyledProperty<Orientation> OrientationProperty = AvaloniaProperty.Register<LabeledMonthYearPicker, Orientation>(
        nameof(Orientation));

    public Orientation Orientation
    {
        get => GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }
    
    public LabeledMonthYearPicker()
    {
        InitializeComponent();
    }
}