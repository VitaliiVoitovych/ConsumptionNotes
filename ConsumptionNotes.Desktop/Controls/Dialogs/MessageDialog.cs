using Avalonia.Platform;
using Avalonia.Svg.Skia;

namespace ConsumptionNotes.Desktop.Controls.Dialogs;

public static class MessageDialog
{
    private const string DefaultCloseButtonText = "OK";

    private static SvgImage LoadSvgImage(string uriString)
    {
        using var stream = AssetLoader.Open(new Uri(uriString));
        var svg = SvgSource.LoadFromStream(stream);
        return new SvgImage { Source = svg };
    }
    
    #region Build Methods
    private static ContentDialog WithImage(this ContentDialog dialog, Image image)
    {
        var container = dialog.Content as StackPanel;
        container?.Children.Insert(0, image);
        return dialog;
    }
    
    private static StackPanel CreateMessageDialogContainer(string text)
    {
        var textBlock = new TextBlock { Text = text };
        
        return new StackPanel
        {
            Spacing = 10,
            Orientation = Orientation.Horizontal,
            VerticalAlignment = VerticalAlignment.Center,
            Children = { textBlock }
        };
    }
    
    private static ContentDialog CreateMessageDialog(string title, string text, string? closeButtonText = null)
    {
        return new ContentDialog
        {
            Title = title,
            Content = CreateMessageDialogContainer(text),
            CloseButtonText = closeButtonText ?? DefaultCloseButtonText,
        };
    }

    #endregion
    
    #region Show methods
    public static async Task ShowAsync(string title, string text, string? closeButtonText = null)
    {
        var dialog = CreateMessageDialog(title, text, closeButtonText);
        await dialog.ShowAsync();
    }

    public static async Task ShowAsync(string title, string text, MessageDialogIcon icon,
        string? closeButtonText = null)
    {
        var uriString = $"avares://ConsumptionNotes/Assets/MessageDialogIcons/{icon.ToString().ToLower()}.svg"; 
        var image = new Image { Source = LoadSvgImage(uriString), Height = 48};

        var dialog = CreateMessageDialog(title, text, closeButtonText).WithImage(image);
        await dialog.ShowAsync();
    }
    #endregion
}