namespace ConsumptionNotes.Desktop.Services.Files;

public static class FileServiceConstants
{
    public static readonly FilePickerFileType JsonFileType = new("Json Files")
    {
        Patterns = ["*.json"],
        AppleUniformTypeIdentifiers = ["public.json"]
    };
}