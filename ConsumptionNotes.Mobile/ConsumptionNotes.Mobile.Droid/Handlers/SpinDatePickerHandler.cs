using MaterialAlertDialogBuilder = Google.Android.Material.Dialog.MaterialAlertDialogBuilder;
using TextInputEditText = Google.Android.Material.TextField.TextInputEditText;
using ColorStateList = Android.Content.Res.ColorStateList;


namespace ConsumptionNotes.Mobile.Droid.Handlers;

public class SpinDatePickerHandler : ViewHandler<SpinDatePicker, TextInputEditText>
{
    private DateOnly Date { get; set; }
    private string? DateFormat { get; set; }
    private TextInputEditText? TextField { get; set; }

    public static IPropertyMapper<SpinDatePicker, SpinDatePickerHandler> PropertyMapper = new PropertyMapper<SpinDatePicker, SpinDatePickerHandler>(ViewMapper)
    {
        [nameof(SpinDatePicker.IsDayVisible)] = MapIsDayVisible, // Always First
        [nameof(SpinDatePicker.SelectedDate)] = MapSelectedDate,
        [nameof(SpinDatePicker.UnderlineColor)] = MapUnderlineColor,
        [nameof(ITextStyle.TextColor)] = MapTextColor,
        [nameof(ITextStyle.Font)] = MapFont,
    };

    public SpinDatePickerHandler() : base(PropertyMapper)
    {

    }

    public SpinDatePickerHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
    {
    }

    protected override TextInputEditText CreatePlatformView()
    {
        TextField = new TextInputEditText(Context)
        {
            TextAlignment = Android.Views.TextAlignment.Center,
            InputType = Android.Text.InputTypes.Null,
            Focusable = true,
            Clickable = true,
        };

        return TextField;
    }

    protected override void ConnectHandler(TextInputEditText platformView)
    {
        platformView.FocusChange += PlatformView_FocusChange;
        platformView.Click += PlatformView_Click;

        base.ConnectHandler(platformView);
    }

    protected override void DisconnectHandler(TextInputEditText platformView)
    {
        platformView.FocusChange -= PlatformView_FocusChange;
        platformView.Click -= PlatformView_Click;

        base.DisconnectHandler(platformView);
    }

    private void PlatformView_FocusChange(object? sender, Android.Views.View.FocusChangeEventArgs e)
    {
        if (e.HasFocus)
        {
            if (PlatformView.Clickable)
                PlatformView.CallOnClick();
            else
                PlatformView_Click(PlatformView, EventArgs.Empty);
        }
    }

    private void PlatformView_Click(object? sender, EventArgs e)
    {
        var datePickerDialogContainer = new SpinDatePickerContainer(Context, Date);
        datePickerDialogContainer.SetDayPickerVisibility(VirtualView.IsDayVisible);

        using var builder = new MaterialAlertDialogBuilder(Context, Resource.Style.CustomMaterialDialogStyle);

        builder.SetTitle(VirtualView.Title);
        builder.SetNegativeButton(Android.Resource.String.Cancel, (o, args) => { });
        builder.SetPositiveButton("Вибрати", (s, args) => VirtualView.SelectedDate = datePickerDialogContainer.SelectedDate);

        builder.SetView(datePickerDialogContainer);

        var dialog = builder.Create();
        dialog.Show();
    }

    private static void MapSelectedDate(SpinDatePickerHandler handler, SpinDatePicker picker)
    {
        handler.Date = picker.SelectedDate;

        handler.PlatformView.Text = picker.SelectedDate.ToString(handler.DateFormat);
    }

    private static void MapIsDayVisible(SpinDatePickerHandler handler, SpinDatePicker picker)
    {
        handler.DateFormat = picker.IsDayVisible ? "dd MMMM yyyy" : "MMMM yyyy";
    }

    private static void MapUnderlineColor(SpinDatePickerHandler handler, SpinDatePicker picker)
    {
        handler.TextField!.BackgroundTintList = ColorStateList.ValueOf(picker.UnderlineColor.ToPlatform());
    }

    private static void MapTextColor(SpinDatePickerHandler handler, SpinDatePicker picker)
    {
        handler.TextField!.UpdateTextColor(picker);
    }

    private static void MapFont(SpinDatePickerHandler handler, SpinDatePicker picker)
    {
        var fontManager = handler.MauiContext?.Services.GetRequiredService<IFontManager>()!;
        handler.TextField!.UpdateFont(picker, fontManager);
    }
}
