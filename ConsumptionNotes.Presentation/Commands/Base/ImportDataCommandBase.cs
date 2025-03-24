using System.Text.Json;

namespace ConsumptionNotes.Presentation.Commands.Base;

public abstract class ImportDataCommandBase<TConsumption, TObservableConsumption>(IObservableNotesService<TConsumption, TObservableConsumption> notesService) 
    : AsyncCommandBase
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
{
    private async Task ImportFromStream(Stream stream)
    {
        var data = await ConsumptionDataSerializer<TConsumption>.DeserializeAsync(stream);
        await notesService.ImportDataAsync(data);
    }
    
    public override async Task ExecuteAsync()
    {
        try
        {
            await using var file = await OpenFileAsync();
            await ImportFromStream(file);
        }
        catch (FileNotSelectedException)
        {
            await HandleFileNotSelectedException();
        }
        catch (JsonException)
        {
            await HandleJsonException();
        }
        catch (InvalidOperationException)
        {
            await HandleInvalidOperationException();
        }
    }

    protected abstract Task<Stream> OpenFileAsync();
    protected abstract Task HandleFileNotSelectedException();
    protected abstract Task HandleJsonException();
    protected abstract Task HandleInvalidOperationException();
}