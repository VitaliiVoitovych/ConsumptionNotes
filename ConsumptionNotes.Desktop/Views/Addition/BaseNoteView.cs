using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.Views.Addition;

public abstract class BaseNoteView : UserControl
{
    private const string AdditionDialogTitle = "Новий запис"; 
    private const string AdditionDialogPrimaryButtonText = "Додати";
    private const string AdditionDialogCloseButtonText = "Відмінити";
    
    protected virtual ContentDialog CreateDialog()
    {
        return new ContentDialog
        {
            Title = AdditionDialogTitle,
            PrimaryButtonText = AdditionDialogPrimaryButtonText,
            CloseButtonText = AdditionDialogCloseButtonText,
            DefaultButton = ContentDialogButton.Primary,
            Content = this,
        };
    }
    
    public async Task<ContentDialogResult> ShowDialogAsync()
    {
        var dialog = CreateDialog();
        return await dialog.ShowAsync();
    }
}