namespace ConsumptionNotes.Mobile.Views;

[ContentProperty(nameof(Content))]
public class BottomSheet : View
{
    public static readonly BindableProperty ContentProperty =
        BindableProperty.Create(nameof(Content), typeof(View), typeof(BottomSheet));

    public View Content
    {
        get => (View)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public static readonly BindableProperty BottomSheetContentProperty =
        BindableProperty.Create(nameof(BottomSheetContent), typeof(View), typeof(BottomSheet));

    public View BottomSheetContent
    {
        get => (View)GetValue(BottomSheetContentProperty);
        set => SetValue(BottomSheetContentProperty, value);
    }

    public static readonly BindableProperty BottomSheetBackgroundColorProperty =
        BindableProperty.Create(nameof(BottomSheetBackgroundColor), typeof(Color), typeof(BottomSheet),
            Colors.Transparent);

    public Color BottomSheetBackgroundColor
    {
        get => (Color)GetValue(BottomSheetBackgroundColorProperty);
        set => SetValue(BottomSheetBackgroundColorProperty, value);
    }

    public static readonly BindableProperty DragHandleColorProperty =
        BindableProperty.Create(nameof(DragHandleColor), typeof(Color), typeof(BottomSheet), Colors.Transparent);

    public Color DragHandleColor
    {
        get => (Color)GetValue(DragHandleColorProperty);
        set => SetValue(DragHandleColorProperty, value);
    }
    
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        
        SetInheritedBindingContext(Content, BindingContext);
        SetInheritedBindingContext(BottomSheetContent, BindingContext);
    }
}