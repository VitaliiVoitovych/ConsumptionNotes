using System.Windows.Input;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Utils.Dialogs;

public static class Dialogs
{
    private const string AdditionDialogTitle = "Новий запис";
    private const string AdditionDialogPrimaryButtonText = "Додати";
    private const string AdditionDialogCloseButtonText = "Відмінити";

    private const string MessageDialogCloseButtonText = "Зрозуміло";
    
    public static async Task<ContentDialogResult> ShowMessageDialog(string title, string message)
    {
        var dialogBuilder = new DialogBuilder();

        var messageDialog = dialogBuilder
            .SetTitle(title)
            .SetContent(message)
            .SetCloseButtonText(MessageDialogCloseButtonText)
            .Build();

        return await messageDialog.ShowAsync();
    }
    
    public static async Task<ContentDialogResult> ShowAdditionDialog(UserControl view, ICommand command)
    {
        var addDialog = new DialogBuilder()
            .SetTitle(AdditionDialogTitle)
            .SetContent(view)
            .SetPrimaryButtonText(AdditionDialogPrimaryButtonText)
            .SetCloseButtonText(AdditionDialogCloseButtonText)
            .SetPrimaryButtonCommand(command)
            .SetDefaultButton(ContentDialogButton.Primary)
            .Build();

        return await addDialog.ShowAsync();
    }
}