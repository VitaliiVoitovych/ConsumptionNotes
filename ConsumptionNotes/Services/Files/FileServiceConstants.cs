using Avalonia.Platform.Storage;

namespace ConsumptionNotes.Services.Files;

public static class FileServiceConstants
{
    private const string FolderPickerDialogTitle = "Виберіть папку для експорту даних";
    private const string FilePickerDialogTitle = "Виберіть файл для імпорту даних";

    public const string OpenFileExceptionMessage = "Не було обрано файл";
    public const string OpenFolderExceptionMessage = "Папка не була вибрана";
    
    private static readonly FilePickerFileType JsonFileType = new("Json Files")
    {
        Patterns = ["*.json"],
        AppleUniformTypeIdentifiers = ["public.json"]
    };
    
    public static readonly FolderPickerOpenOptions FolderPickerOpenOptions = new()
    {
        Title = FolderPickerDialogTitle,
        AllowMultiple = false,
    };
    
    public static readonly FilePickerOpenOptions FilePickerOpenOptions = new()
    {
        Title = FilePickerDialogTitle,
        FileTypeFilter = [JsonFileType],
        AllowMultiple = false
    };
}