using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Mobile.Commands;

public class AddNoteCommand(Action addNote)
{
    private IAsyncRelayCommand? _command;
    
    public IAsyncRelayCommand Command => _command ??= new AsyncRelayCommand(Add);
    
    private async Task Add()
    {
        try
        {
            addNote.Invoke();
        }
        catch (DuplicateConsumptionNoteException)
        {
            await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.DuplicateNoteErrorMessage, "Зрозуміло");
        }
        catch (InvalidConsumptionDataException)
        {
            await Shell.Current.DisplayAlert("Помилка!", ExceptionMessages.InvalidDateErrorMessage, "Зрозуміло");
        }
    }
}