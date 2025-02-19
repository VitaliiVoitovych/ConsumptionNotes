namespace ConsumptionNotes.Presentation.Commands.Base;

public abstract class AddNoteCommandBase(Action addNote) : AsyncCommandBase
{
    public override async Task ExecuteAsync()
    {
        try
        {
            addNote.Invoke();
        }
        catch (DuplicateConsumptionNoteException)
        {
            await HandleDuplicateConsumptionNoteException();
        }
        catch (InvalidConsumptionDataException)
        {
            await HandleInvalidConsumptionDataException();
        }
    }

    protected abstract Task HandleDuplicateConsumptionNoteException();
    protected abstract Task HandleInvalidConsumptionDataException();
}