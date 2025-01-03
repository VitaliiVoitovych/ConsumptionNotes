using ConsumptionNotes.Application.Services.Files;
using ConsumptionNotes.Application.Services.Notes.Interfaces;
using ConsumptionNotes.Mobile.Services.Files;
using System.Text.Json;

namespace ConsumptionNotes.Mobile.ViewModels.Dashboards;

public abstract partial class BaseDashboardViewModel<TConsumption, TChartService, TNotesService>(TNotesService notesService, FileService fileService) : ObservableObject
    where TConsumption : BaseConsumption
    where TChartService : BaseChartService<TConsumption>
    where TNotesService : INotesChartService<TConsumption, TChartService>
{
    private const string JsonFileNotSelectedMessage = "Не обрали потрібний файл з даними";

    protected abstract string ExportFileName { get; }

    protected abstract string AddPageRoute { get; }

    public TNotesService NotesService { get; } = notesService;
    public TChartService ChartService => NotesService.ChartService;

    [RelayCommand]
    private void Remove(TConsumption consumption)
    {
        NotesService.RemoveNote(consumption);
    }

    [RelayCommand]
    private async Task OpenAddPage()
    {
        await Shell.Current.GoToAsync(AddPageRoute, true);
    }

    [RelayCommand]
    private async Task ImportData()
    {
        try
        {
            var file = await fileService.OpenFileAsync();
            var data = await DataExporterImporter<TConsumption>.ImportAsync(file);
            await NotesService.ImportDataAsync(data);
        }
        catch (FileNotFoundException ex)
        {
            await Shell.Current.DisplayAlert("Помилка!", ex.Message, "Зрозуміло");
        }
        catch (JsonException)
        {
            await Shell.Current.DisplayAlert("Помилка!", JsonFileNotSelectedMessage, "Зрозуміло");
        }
    }

    [RelayCommand]
    private async Task ExportData()
    {
        var filename = $"{ExportFileName}_{DateTime.UtcNow:dd-MM-yyyy}.json";
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);

        await DataExporterImporter<TConsumption>.ExportAsync(filePath, NotesService.Consumptions);

        await fileService.ShareFileAsync(filePath);
        try
        {
            File.Delete(filePath);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Помилка", ex.Message, "Зрозуміло");
        }
    }
}
