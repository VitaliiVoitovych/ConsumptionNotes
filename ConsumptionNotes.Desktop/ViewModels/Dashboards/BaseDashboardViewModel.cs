using System.Text.Json;
using ConsumptionNotes.Desktop.Controls.Dialogs;
using ConsumptionNotes.Application.Services.Files;
using ConsumptionNotes.Desktop.Services.Files;
using ConsumptionNotes.Application.Services.Notes.Interfaces;
using ConsumptionNotes.Desktop.Extensions;
using ConsumptionNotes.Domain.Exceptions;
using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.Desktop.ViewModels.Dashboards;

public abstract partial class BaseDashboardViewModel<TConsumption, TChartService, TNotesService>(TNotesService notesService, FileSystemService fileSystemService) : ViewModelBase
    where TConsumption : BaseConsumption
    where TChartService : BaseChartService<TConsumption>
    where TNotesService : INotesChartService<TConsumption, TChartService>
{
    protected abstract string ExportFileName { get; }
    
    protected abstract UserControl AddingView { get; }
    
    public TNotesService NotesService { get; } = notesService;

    public TChartService ChartService => NotesService.ChartService;
    
    [RelayCommand]
    private void Remove(TConsumption consumption)
    {
        NotesService.RemoveNote(consumption);
    }

    [RelayCommand]
    private async Task OpenAddingDialog()
    {
        var viewmodel = AddingView.DataContext as BaseAddViewModel<TConsumption, TNotesService>;
        await AddingView.ShowContentDialog("Новий запис", "Відмінити", "Додати", ContentDialogButton.Primary, viewmodel!.AddCommand);
    }
    
    [RelayCommand]
    private async Task ImportData()
    {
        try
        {
            await using var stream = await fileSystemService.OpenFileAsync("Виберіть файл для імпорту даних", FileServiceConstants.JsonFileType);
            var data = await DataExporterImporter<TConsumption>.ImportAsync(stream);
            await NotesService.ImportDataAsync(data);
        }
        catch (JsonException)
        {
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.JsonFileNotSelectedMessage, MessageDialogIcon.Error);
        }
        catch (FileNotSelectedException)
        {
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.FileNotSelectedExceptionMessage, MessageDialogIcon.Error);
        }
    }
    
    [RelayCommand]
    private async Task ExportData()
    {
        var exportFile = $"{ExportFileName}_{DateTime.UtcNow:dd-MM-yyyy}.json";

        try
        {
            var folderPath = await fileSystemService.OpenFolderAsync("Виберіть папку для експорту даних");
            var filePath = Path.Combine(folderPath, exportFile);
            await DataExporterImporter<TConsumption>.ExportAsync(filePath, NotesService.Consumptions);
            await MessageDialog.ShowAsync("Дані успішно експортовано!", $"Дані експортовано за місцем \r\n{filePath}");
        }
        catch (FolderNotSelectedException)
        {
            await MessageDialog.ShowAsync("Помилка", ExceptionMessages.FolderNotSelectedExceptionMessage, MessageDialogIcon.Error);
        }
    }
}