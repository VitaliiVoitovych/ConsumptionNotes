using System.IO;
using System.Text.Json;
using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Utils.Dialogs;
using ConsumptionNotes.Views.Addition;

namespace ConsumptionNotes.ViewModels;

public partial class NaturalGasDashboardViewModel(NaturalGasNotesService notesService, FileService fileService) : ViewModelBase
{
    public NaturalGasNotesService NotesService { get; } = notesService;
    public NaturalGasChartService ChartService => NotesService.ChartService;
    
    [RelayCommand]
    private async Task OpenAddDialog()
    {
        var addView = Ioc.Default.GetRequiredService<NaturalGasNoteView>();
        var addViewModel = addView.DataContext as NaturalGasNoteViewModel;

        var addDialog = Dialogs.CreateAdditionDialog(addView, addViewModel!.AddCommand);
        await addDialog.ShowAsync();
    }

    [RelayCommand]
    private void Remove(NaturalGasConsumption consumption)
    {
        NotesService.RemoveNote(consumption);
    }
    
    [RelayCommand]
    private async Task ImportData()
    {
        try
        {
            await using var stream = await fileService.OpenFileAsync();
            var data = DataExporterImporter.Import<NaturalGasConsumption>(stream);

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
        const string fileName = "naturalgas";
        var exportFile = $"{fileName}_{DateTime.UtcNow:dd-MM-yyyy}.json";
        
        var folderPath = await fileService.OpenFolderAsync();
        var filePath = Path.Combine(folderPath, exportFile);
        await DataExporterImporter.ExportAsync(filePath, NotesService.Consumptions);
    }
}