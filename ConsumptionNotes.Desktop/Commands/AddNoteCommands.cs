using ConsumptionNotes.Application.Commands.Base;
using ConsumptionNotes.Desktop.Controls.Dialogs;

namespace ConsumptionNotes.Desktop.Commands;

public class AddNoteCommands(Action addNote) : AddNoteCommandBase(addNote)
{
    protected override async Task HandleDuplicateConsumptionNoteException()
    {
        await MessageDialog.ShowAsync("Помилка", ExceptionMessages.DuplicateNoteErrorMessage, MessageDialogIcon.Warning);
    }

    protected override async Task HandleInvalidConsumptionDataException()
    {
        await MessageDialog.ShowAsync("Помилка", ExceptionMessages.InvalidDateErrorMessage, MessageDialogIcon.Warning);
    }
}