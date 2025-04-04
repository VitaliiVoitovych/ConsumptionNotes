using ConsumptionNotes.Presentation.Commands.Base;

namespace ConsumptionNotes.Mobile.Commands;

public class ExportDataCommand<TConsumption>(FileSystemService fileSystemService)
    : ExportDataCommandBase<TConsumption>
    where TConsumption : ConsumptionBase
{
    public override async Task ExecuteAsync(IEnumerable<TConsumption>? collection)
    {
        if (collection is null) return;
        var filePath = await WriteToFile(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), collection);
        
        await fileSystemService.ShareFileAsync(filePath, "Експортувати дані");
        if(File.Exists(filePath)) File.Delete(filePath);
    }
}