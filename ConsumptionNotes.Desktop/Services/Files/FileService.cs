using Avalonia.Platform.Storage;

namespace ConsumptionNotes.Desktop.Services.Files;

public class FileService
{
    private readonly IStorageProvider _storageProvider;

    public FileService(IStorageProvider storageProvider)
    {
        _storageProvider = storageProvider;
    }

    public async Task<Stream> OpenFileAsync()
    {
        var files = await _storageProvider.OpenFilePickerAsync(FileServiceConstants.FilePickerOpenOptions);

        var file = files.Count > 0 ? files[0] : throw new FileNotFoundException(FileServiceConstants.OpenFileExceptionMessage);
        
        return await file.OpenReadAsync();
    }
    
    public async Task<string> OpenFolderAsync()
    {
        var folders = await _storageProvider.OpenFolderPickerAsync(FileServiceConstants.FolderPickerOpenOptions);

        var exportFolder = folders.Count > 0 ? folders[0] : throw new IOException(FileServiceConstants.OpenFolderExceptionMessage);

        return exportFolder.Path.LocalPath;
    }
}