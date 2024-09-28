using Avalonia;

namespace ConsumptionNotes.Controls;

public partial class LabeledNumericUpDown : UserControl
{
    public static readonly StyledProperty<string?> TextProperty = AvaloniaProperty.Register<LabeledNumericUpDown, string?>(
        nameof(Text));

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly StyledProperty<decimal> MinimumProperty = AvaloniaProperty.Register<LabeledNumericUpDown, decimal>(
        nameof(Minimum));

    public decimal Minimum
    {
        get => GetValue(MinimumProperty);
        set => SetValue(MinimumProperty, value);
    }

    public static readonly StyledProperty<decimal> MaximumProperty = AvaloniaProperty.Register<LabeledNumericUpDown, decimal>(
        nameof(Maximum));

    public decimal Maximum
    {
        get => GetValue(MaximumProperty);
        set => SetValue(MaximumProperty, value);
    }

    public static readonly StyledProperty<decimal> IncrementProperty = AvaloniaProperty.Register<LabeledNumericUpDown, decimal>(
        nameof(Increment));

    public decimal Increment
    {
        get => GetValue(IncrementProperty);
        set => SetValue(IncrementProperty, value);
    }

    public static readonly StyledProperty<decimal?> ValueProperty = AvaloniaProperty.Register<LabeledNumericUpDown, decimal?>(
        nameof(Value));

    public decimal? Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    
    public LabeledNumericUpDown()
    {
        InitializeComponent();
    }
}