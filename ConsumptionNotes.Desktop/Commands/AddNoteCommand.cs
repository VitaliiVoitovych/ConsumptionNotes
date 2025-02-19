using ConsumptionNotes.Presentation.Commands.Base;

namespace ConsumptionNotes.Desktop.Commands;

public class AddNoteCommand(Action addNote) : AddNoteCommandBase(addNote)
{
    protected override async Task HandleDuplicateConsumptionNoteException()
    {
        await MessageDialog.ShowAsync("Помилка", "Запис про цей місяць вже є", MessageDialogIcon.Warning);
    }

    protected override async Task HandleInvalidConsumptionDataException()
    {
        await MessageDialog.ShowAsync("Помилка", "Не можна додавати запис \r\nпро поточний чи майбутній місяць", MessageDialogIcon.Warning);
    }
}