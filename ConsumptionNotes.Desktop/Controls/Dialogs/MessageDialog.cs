namespace ConsumptionNotes.Desktop.Controls.Dialogs;

public static class MessageDialog
{
    private const string DefaultCloseButtonText = "OK";
    
    #region Build Methods
    private static ContentDialog AddIcon(this ContentDialog dialog, Image image)
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
        var image = new Image { Source = AssetsExtensions.LoadSvgFromAssets(uriString), Height = 48};

        var dialog = CreateMessageDialog(title, text, closeButtonText).AddIcon(image);
        await dialog.ShowAsync();
    }
    #endregion
}