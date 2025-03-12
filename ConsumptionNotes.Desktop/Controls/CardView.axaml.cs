using Avalonia.Media;

namespace ConsumptionNotes.Desktop.Controls;

public partial class CardView : Border
{
    public static readonly StyledProperty<string?> TitleProperty = AvaloniaProperty.Register<CardView, string?>(
        nameof(Title));

    public string? Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly StyledProperty<IImage?> IconProperty =
        AvaloniaProperty.Register<CardView, IImage?>(nameof(Icon));

    public IImage? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly StyledProperty<IBrush?> LineColorProperty =
        AvaloniaProperty.Register<CardView, IBrush?>(nameof(LineColor));

    public IBrush? LineColor
    {
        get => GetValue(LineColorProperty);
        set => SetValue(LineColorProperty, value);
    }

    public static readonly StyledProperty<object?> ContentProperty =
        AvaloniaProperty.Register<CardView, object?>(nameof(Content));
    
    public object? Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
    
    public CardView()
    {
        InitializeComponent();
    }
}