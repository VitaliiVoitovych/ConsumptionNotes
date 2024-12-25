using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes;
using ConsumptionNotes.Domain.Models;
using ConsumptionNotes.Mobile.Pages;
using ConsumptionNotes.Mobile.Services.Files;
using System.Text.Json;

namespace ConsumptionNotes.Mobile.ViewModels;

public partial class ElectricityDashboardViewModel(ElectricityNotesService notesService, FileService fileService) : ObservableObject
{
    public ElectricityNotesService NotesService => notesService;
    public ElectricityChartService ChartService => NotesService.ChartService;

    [RelayCommand]
    private void Remove(ElectricityConsumption consumption)
    {
        NotesService.RemoveNote(consumption);
    }

    [RelayCommand]
    private async Task OpenAddPage()
    {
        await Shell.Current.GoToAsync(nameof(AddElectricityPage), true);
    }

    [RelayCommand]
    private async Task ExportData()
    {
        var filename = $"electricity_{DateTime.UtcNow:dd-MM-yyyy}.json";
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);

        await DataExporterImporter.ExportAsync(filePath, NotesService.Consumptions);

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

    [RelayCommand]
    private async Task ImportData()
    {
        try
        {
            var file = await fileService.OpenFileAsync();
            var data = await DataExporterImporter.ImportAsync<ElectricityConsumption>(file);
            await NotesService.ImportDataAsync(data);
        }
        catch (FileNotFoundException ex)
        {
            await Shell.Current.DisplayAlert("Помилка!", ex.Message, "Зрозуміло");
        }
        catch (JsonException)
        {
            await Shell.Current.DisplayAlert("Помилка!", "Ви обрали не файл з даними!", "Зрозуміло");
        }
    }
}