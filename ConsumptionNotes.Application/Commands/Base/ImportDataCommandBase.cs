using System.Text.Json;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Application.Commands.Base;

public abstract class ImportDataCommandBase(Func<Stream, Task> importFromStream) : AsyncCommandBase
{
    public override async Task ExecuteAsync()
    {
        try
        {
            await using var file = await OpenFileAsync();
            await importFromStream.Invoke(file);
        }
        catch (FileNotSelectedException)
        {
            await HandleFileNotSelectedException();
        }
        catch (JsonException)
        {
            await HandleJsonException();
        }
    }

    protected abstract Task<Stream> OpenFileAsync();
    protected abstract Task HandleFileNotSelectedException();
    protected abstract Task HandleJsonException();
}