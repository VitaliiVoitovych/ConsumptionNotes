namespace ConsumptionNotes.Desktop.Services.Files;

public class FileSystemService(IStorageProvider storageProvider)
{
    public async Task<Stream> OpenFileAsync(string? title = null, params IReadOnlyList<FilePickerFileType> filePickerFileTypes)
    {
        var filePickerOpenOptions = new FilePickerOpenOptions
        {
            Title = title,
            FileTypeFilter = filePickerFileTypes,
            AllowMultiple = false
        };

        var files = await storageProvider.OpenFilePickerAsync(filePickerOpenOptions);

        var file = files.Count > 0 ? files[0] : throw new FileNotSelectedException("File not selected");

        return await file.OpenReadAsync();
    }

    public async Task<string> OpenFolderAsync(string? title = null)
    {
        var folderPickerOpenOptions = new FolderPickerOpenOptions
        {
            Title = title,
            AllowMultiple = false,
        };

        var folders = await storageProvider.OpenFolderPickerAsync(folderPickerOpenOptions);

        var exportFolder = folders.Count > 0 ? folders[0] : throw new FolderNotSelectedException("Folder not selected");

        return exportFolder.Path.LocalPath;
    }
}
