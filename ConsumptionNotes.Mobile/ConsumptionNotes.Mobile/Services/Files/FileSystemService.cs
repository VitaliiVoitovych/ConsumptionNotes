using ConsumptionNotes.Domain.Exceptions;

namespace ConsumptionNotes.Mobile.Services.Files;

public class FileSystemService
{
    public async Task<Stream> OpenFileAsync(PickOptions pickOptions, string? title = null)
    {
        pickOptions.PickerTitle = title;

        var result = await FilePicker.Default.PickAsync(pickOptions) ?? throw new FileNotSelectedException("File not selected");
        return await result.OpenReadAsync();
    }

    public async Task ShareFileAsync(string filePath, string? title = null)
    {
        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = title,
            File = new ShareFile(filePath)
        });
    }
}