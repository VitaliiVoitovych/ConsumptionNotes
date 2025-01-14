using ConsumptionNotes.Mobile.Services.Files;

namespace ConsumptionNotes.Mobile.Commands;

public class ExportDataCommand(FileSystemService fileSystemService, Func<string, Task<string>> writeToFile)
{
    private IAsyncRelayCommand? _command;
    
    public IAsyncRelayCommand Command => _command ??= new AsyncRelayCommand(Export);

    private async Task Export()
    {
        var filePath = await writeToFile.Invoke(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        
        await fileSystemService.ShareFileAsync(filePath, "Експортувати дані");
        if(File.Exists(filePath)) File.Delete(filePath);
    }
}