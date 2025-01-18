using AButton = Android.Widget.Button;
using ColorStateList = Android.Content.Res.ColorStateList;
using InputTypes = Android.Text.InputTypes;
using TextInputEditText = Google.Android.Material.TextField.TextInputEditText;

namespace ConsumptionNotes.Mobile.Droid.Handlers;

public class NumericUpDownHandler : StepperHandler
{
    private AButton? UpButton { get; set; }
    private AButton? DownButton { get; set; }
    private TextInputEditText? TextField { get; set; }
    public new NumericUpDown VirtualView => (NumericUpDown)base.VirtualView;

    public static IPropertyMapper<IStepper, IStepperHandler> PropertyMapper = new PropertyMapper<NumericUpDown, NumericUpDownHandler>(ViewHandler.ViewMapper)
    {
        [nameof(ITextStyle.TextColor)] = MapTextColor,
        [nameof(ITextStyle.Font)] = MapFont,
        [nameof(NumericUpDown.Value)] = MapValue,
        [nameof(NumericUpDown.Increment)] = MapIncrement,
        [nameof(NumericUpDown.UnderlineColor)] = MapUnderlineColor,
        [nameof(NumericUpDown.ButtonBackgroundColor)] = MapButtonBackgroundColor,
        [nameof(NumericUpDown.ButtonForegroundColor)] = MapButtonTextColor,
    };

    protected override MauiStepper CreatePlatformView()
    {
        var stepper = base.CreatePlatformView();

        UpButton = (AButton)stepper.GetChildAt(stepper.ChildCount - 1)!;
        DownButton = (AButton)stepper.GetChildAt(stepper.ChildCount - 2)!;

        TextField = new TextInputEditText(Context)
        {
            InputType = InputTypes.ClassNumber | InputTypes.NumberFlagSigned,
            EmojiCompatEnabled = false,
        };
        TextField.SetMinWidth((int)Context.ToPixels(120));

        stepper.AddView(TextField, 0);

        return stepper;
    }

    public NumericUpDownHandler() : base(PropertyMapper)
    {

    }

    public NumericUpDownHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
    {

    }

    protected override void ConnectHandler(MauiStepper platformView)
    {
        base.ConnectHandler(platformView);

        TextField!.TextChanged += OnEntryTextChanged;
    }

    protected override void DisconnectHandler(MauiStepper platformView)
    {
        base.DisconnectHandler(platformView);

        TextField!.TextChanged -= OnEntryTextChanged;
    }

    private void OnEntryTextChanged(object? sender, Android.Text.TextChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TextField!.Text))
        {
            VirtualView.Value = 0.0;
            TextField.Text = $"{VirtualView.Value}";
            return;
        }
        if (double.TryParse(TextField!.Text, out var value))
        {
            if (value >= VirtualView.Minimum && value <= VirtualView.Maximum)
            {
                VirtualView.Value = value;
                TextField.SetSelection(TextField.Text.Length);
            }
        }
    }

    private static void MapValue(NumericUpDownHandler handler, NumericUpDown numericUpDown)
    {
        handler.PlatformView.UpdateValue(numericUpDown);

        handler.TextField!.Text = numericUpDown.Value.ToString();
    }

    private static void MapIncrement(NumericUpDownHandler handler, NumericUpDown numericUpDown)
    {
        handler.PlatformView.UpdateIncrement(numericUpDown);

        if (!double.IsInteger(numericUpDown.Increment))
        {
            handler.TextField!.InputType |= InputTypes.NumberFlagDecimal;
            handler.TextField.KeyListener = LocalizedDigitsKeyListener.Create(handler.TextField.InputType);
        }
    }

    private static void MapUnderlineColor(NumericUpDownHandler handler, NumericUpDown numericUpDown)
    {
        handler.TextField!.BackgroundTintList = ColorStateList.ValueOf(numericUpDown.UnderlineColor.ToPlatform());
    }

    private static void MapButtonBackgroundColor(NumericUpDownHandler handler, NumericUpDown numericUpDown)
    {
        var buttonBackgroundColor = numericUpDown.ButtonBackgroundColor.ToPlatform();

        handler.UpButton!.BackgroundTintList = ColorStateList.ValueOf(buttonBackgroundColor);
        handler.DownButton!.BackgroundTintList = ColorStateList.ValueOf(buttonBackgroundColor);
    }

    private static void MapTextColor(NumericUpDownHandler handler, NumericUpDown numericUpDown)
    {
        handler.TextField!.UpdateTextColor(numericUpDown);
        
        // TODO: Text field Cursor styling: Color (Solved. Need Review) | need API 29
        //handler.TextField!.TextCursorDrawable.SetTintList(ColorStateList.ValueOf(numericUpDown.TextColor.ToPlatform()));
    }

    private static void MapFont(NumericUpDownHandler handler, NumericUpDown numericUpDown)
    {
        var fontManager = handler.MauiContext?.Services.GetRequiredService<IFontManager>()!;
        handler.TextField!.UpdateFont(numericUpDown, fontManager);

        handler.UpButton!.UpdateFont(numericUpDown, fontManager);
        handler.DownButton!.UpdateFont(numericUpDown, fontManager);
    }

    private static void MapButtonTextColor(NumericUpDownHandler handler, NumericUpDown numericUpDown)
    {
        var enabledTextColor = numericUpDown.ButtonForegroundColor.ToPlatform();
        var disabledTextColor = Android.Graphics.Color.Argb(130, enabledTextColor.R, enabledTextColor.G, enabledTextColor.B);

        var states = new int[][]
        {
            [Android.Resource.Attribute.StateEnabled],
            [-Android.Resource.Attribute.StateEnabled],
        };

        int[] colors = [enabledTextColor, disabledTextColor];

        var textColorList = new ColorStateList(states, colors);

        handler.UpButton!.SetTextColor(textColorList);
        handler.DownButton!.SetTextColor(textColorList);
    }
}
