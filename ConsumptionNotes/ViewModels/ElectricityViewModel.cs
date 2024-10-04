using System.IO;
using System.Text.Json;
using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Utils.Dialogs;
using ConsumptionNotes.Views.Addition;

namespace ConsumptionNotes.ViewModels;

public partial class ElectricityViewModel(ElectricityNotesService notesService, FileService fileService) : ViewModelBase
{
    public ElectricityNotesService NotesService => notesService;
    public ElectricityChartService ChartService => notesService.ChartService;

    [RelayCommand]
    private async Task OpenAddDialog()
    {
        var addView = Ioc.Default.GetRequiredService<ElectricityNoteView>();
        var addViewModel = addView.DataContext as ElectricityNoteViewModel;

        var addDialog = Dialogs.CreateAdditionDialog(addView, addViewModel!.AddCommand);
        await addDialog.ShowAsync();
    }

    [RelayCommand]
    private void Remove(ElectricityConsumption consumption)
    {
        notesService.RemoveNote(consumption);
    }

    [RelayCommand]
    private async Task ImportData()
    {
        try
        {
            await using var stream = await fileService.OpenFileAsync();
            var data = DataExporterImporter.Import<ElectricityConsumption>(stream);

            await NotesService.ImportDataAsync(data);
        }
        catch (FileNotFoundException e)
        {
            var messageDialog = Dialogs.CreateMessageDialog("Помилка", e.Message);
            await messageDialog.ShowAsync();
        }
        catch (JsonException)
        {
            var messageDialog = Dialogs.CreateMessageDialog("Помилка", "Ви обрали не файл з даними");
            await messageDialog.ShowAsync();
        }
    }

    [RelayCommand]
    private async Task ExportData()
    {
        const string fileName = "electricity";
        var exportFile = $"{fileName}_{DateTime.UtcNow:dd-MM-yyyy}.json";
        
        var folderPath = await fileService.OpenFolderAsync();
        var filePath = Path.Combine(folderPath, exportFile);
        await DataExporterImporter.ExportAsync(filePath, NotesService.Consumptions);
    }
}