using System.Text.Json;
using ConsumptionNotes.Controls.Dialogs;
using ConsumptionNotes.Services.Files;
using ConsumptionNotes.Services.Notes.Interfaces;
using ConsumptionNotes.Views.Addition;

namespace ConsumptionNotes.ViewModels.Dashboards;

public abstract partial class BaseDashboardViewModel<TConsumption, TChartService, TNotesService>(TNotesService notesService, FileService fileService) : ViewModelBase
    where TConsumption : BaseConsumption
    where TChartService : BaseChartService<TConsumption>
    where TNotesService : INotesChartService<TConsumption, TChartService>
{
    private const string JsonFileNotSelectedMessage  = "Не обрали потрібний файл з даними";
    
    private readonly FileService _fileService = fileService;

    protected abstract string ExportFileName { get; }
    
    public TNotesService NotesService { get; } = notesService;

    public TChartService ChartService => NotesService.ChartService;

    protected abstract BaseNoteView GetNoteView();
    
    [RelayCommand]
    private void Remove(TConsumption consumption)
    {
        NotesService.RemoveNote(consumption);
    }

    [RelayCommand]
    private async Task OpenAddDialog()
    {
        var noteView = GetNoteView();
        await noteView.ShowDialogAsync();
    }
    
    [RelayCommand]
    private async Task ImportData()
    {
        try
        {
            await using var stream = await _fileService.OpenFileAsync();
            var data = await DataExporterImporter.ImportAsync<TConsumption>(stream);
            await NotesService.ImportDataAsync(data);
        }
        catch (JsonException)
        {
            await MessageDialog.ShowAsync("Помилка", JsonFileNotSelectedMessage, MessageDialogIcon.Error);
        }
        catch (FileNotFoundException ex)
        {
            await MessageDialog.ShowAsync("Помилка", ex.Message, MessageDialogIcon.Error);
        }
    }
    
    [RelayCommand]
    private async Task ExportData()
    {
        var exportFile = $"{ExportFileName}_{DateTime.UtcNow:dd-MM-yyyy}.json";

        try
        {
            var folderPath = await _fileService.OpenFolderAsync();
            var filePath = Path.Combine(folderPath, exportFile);
            await DataExporterImporter.ExportAsync(filePath, NotesService.Consumptions);
            await MessageDialog.ShowAsync("Дані успішно експортовано!", $"Дані експортовано за місцем \r\n{filePath}");
        }
        catch (IOException ex)
        {
            await MessageDialog.ShowAsync("Помилка", ex.Message, MessageDialogIcon.Error);
        }
    }
}