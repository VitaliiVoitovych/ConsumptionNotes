namespace ConsumptionNotes.Mobile.Services.Files;

public static class FileServiceConstants
{
    private static readonly FilePickerFileType Json = new(new Dictionary<DevicePlatform, IEnumerable<string>>
    {
        { DevicePlatform.Android, ["application/json"] }
    });
    
    public static readonly PickOptions JsonPickOptions = new()
    {
        FileTypes = Json
    };
}