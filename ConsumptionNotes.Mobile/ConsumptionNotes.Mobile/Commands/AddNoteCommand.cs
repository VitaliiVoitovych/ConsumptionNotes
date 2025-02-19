using ConsumptionNotes.Presentation.Commands.Base;

namespace ConsumptionNotes.Mobile.Commands;

public class AddNoteCommand(Action addNote) : AddNoteCommandBase(addNote)
{
    protected override async Task HandleDuplicateConsumptionNoteException()
    {
        await Shell.Current.DisplayAlert("Помилка!", "Запис про цей місяць вже є", "Зрозуміло");
    }

    protected override async Task HandleInvalidConsumptionDataException()
    {
        await Shell.Current.DisplayAlert("Помилка!", "Не можна додавати запис \r\nпро поточний чи майбутній місяць", "Зрозуміло");
    }
}