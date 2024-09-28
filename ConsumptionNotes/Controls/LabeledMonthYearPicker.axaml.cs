using Avalonia;

namespace ConsumptionNotes.Controls;

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
    
    public LabeledMonthYearPicker()
    {
        InitializeComponent();
    }
}