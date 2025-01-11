using System.Windows.Input;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.Extensions;

public static class DialogExtensions
{
    public static async Task<ContentDialogResult> ShowContentDialog(
        this Control control, 
        string? title = null, 
        string? closeButtonText = null, 
        string? primaryButtonText = null,
        ContentDialogButton defaultButton = ContentDialogButton.None,
        ICommand? command = null)
    {
        var dialog = new ContentDialog
        {
            Title = title,
            PrimaryButtonText = primaryButtonText,
            PrimaryButtonCommand = defaultButton == ContentDialogButton.Primary ? command : null,
            CloseButtonText = closeButtonText,
            DefaultButton = defaultButton,
            Content = control,
        };

        return await dialog.ShowAsync();
    }
}