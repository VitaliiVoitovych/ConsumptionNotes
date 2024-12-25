namespace ConsumptionNotes.Mobile.Services.Files;

public class FileService
{
    private readonly PickOptions pickOptions = new()
    {
        PickerTitle = FileServicesConstants.FilePickerTitle,
        FileTypes = FileServicesConstants.FilePickerFileType
    };

    public async Task<Stream> OpenFileAsync()
    {
        var result = await FilePicker.Default.PickAsync(pickOptions) ?? throw new FileNotFoundException(FileServicesConstants.OpenFileExceptionMessage);
        return await result.OpenReadAsync();
    }

    public async Task ShareFileAsync(string filePath)
    {
        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = FileServicesConstants.ShareFileTitle,
            File = new ShareFile(filePath)
        });
    }
}