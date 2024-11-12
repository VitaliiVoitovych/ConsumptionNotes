using System.Windows.Input;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Utils.Dialogs;

public static class Dialogs
{
    private const string AdditionDialogTitle = "Новий запис";
    private const string AdditionDialogPrimaryButtonText = "Додати";
    private const string AdditionDialogCloseButtonText = "Відмінити";
    
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