namespace ConsumptionNotes.Presentation.Commands.Base;

public abstract class ExportDataCommandBase<TConsumption> : AsyncCommandBase<IEnumerable<TConsumption>>
    where TConsumption : ConsumptionBase
{
    private readonly string _exportFilename = typeof(TConsumption).Name;
    protected async Task<string> WriteToFile(string folderPath, IEnumerable<TConsumption> collection)
    {
        var filename = $"{_exportFilename}_{DateTime.UtcNow:dd-MM-yyyy}.json";
        var filePath = Path.Combine(folderPath, filename);

        await ConsumptionDataSerializer<TConsumption>.SerializeAsync(filePath, collection);
        
        return filePath;
    }
}