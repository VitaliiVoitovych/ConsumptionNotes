using ConsumptionNotes.Application.Commands.Base;

namespace ConsumptionNotes.Mobile.Commands;

public class AddNoteCommand(Action addNote) : AddNoteCommandBase(addNote)
{
    protected override async Task HandleDuplicateConsumptionNoteException()
    {
        await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.DuplicateNoteErrorMessage, "Зрозуміло");
    }

    protected override async Task HandleInvalidConsumptionDataException()
    {
        await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.InvalidDateErrorMessage, "Зрозуміло");
    }
}