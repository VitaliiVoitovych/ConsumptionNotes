using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Mobile.Services.Files;

public class FileService
{
    public static readonly FilePickerFileType Json = new(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.Android, ["application/json"] }
            });

    public async Task<Stream> OpenFileAsync(FilePickerFileType filePickerFileType, string? title = default)
    {
        var pickOptions = new PickOptions()
        {
            PickerTitle = title,
            FileTypes = filePickerFileType,
        };

        var result = await FilePicker.Default.PickAsync(pickOptions) ?? throw new FileNotSelectedException("File not selected");
        return await result.OpenReadAsync();
    }

    public async Task ShareFileAsync(string filePath, string? title = default)
    {
        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = title,
            File = new ShareFile(filePath)
        });
    }
}