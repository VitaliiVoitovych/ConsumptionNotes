using ConsumptionNotes.Desktop.Controls.Dialogs;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Desktop.Commands;

public class AddNoteCommands(Action addNote)
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
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.DuplicateNoteErrorMessage, MessageDialogIcon.Warning);
        }
        catch (InvalidConsumptionDataException)
        {
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.InvalidDateErrorMessage, MessageDialogIcon.Warning);
        }
    }
}