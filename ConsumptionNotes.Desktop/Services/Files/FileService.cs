using Avalonia.Platform.Storage;
using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Desktop.Services.Files;

public class FileService
{
    private readonly IStorageProvider _storageProvider;

    public FileService(IStorageProvider storageProvider)
    {
        _storageProvider = storageProvider;
    }

    public async Task<Stream> OpenFileAsync(string? title = default, bool allowMultiple = false, params IReadOnlyList<FilePickerFileType> filePickerFileTypes)
    {
        var filePickerOpenOptions = new FilePickerOpenOptions()
        {
            Title = title,
            FileTypeFilter = filePickerFileTypes,
            AllowMultiple = allowMultiple
        };

        var files = await _storageProvider.OpenFilePickerAsync(filePickerOpenOptions);

        var file = files.Count > 0 ? files[0] : throw new FileNotSelectedException("File not selected");

        return await file.OpenReadAsync();
    }

    public async Task<string> OpenFolderAsync(string? title = default, bool allowMultiple = false)
    {
        var folderPickerOpenOptions = new FolderPickerOpenOptions()
        {
            Title = title,
            AllowMultiple = allowMultiple,
        };

        var folders = await _storageProvider.OpenFolderPickerAsync(folderPickerOpenOptions);

        var exportFolder = folders.Count > 0 ? folders[0] : throw new FolderNotSelectedException("Folder not selected");

        return exportFolder.Path.LocalPath;
    }
}
