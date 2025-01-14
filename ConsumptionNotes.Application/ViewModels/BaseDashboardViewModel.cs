using CommunityToolkit.Mvvm.Input;
using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Files;
using ConsumptionNotes.Application.Services.Notes.Interfaces;

namespace ConsumptionNotes.Application.ViewModels;

public abstract partial class BaseDashboardViewModel<TConsumption, TChartService, TNotesService>(TNotesService notesService) : ViewModelBase
    where TConsumption : BaseConsumption
    where TChartService : BaseChartService<TConsumption>
    where TNotesService : INotesChartService<TConsumption, TChartService>
{
    private readonly string _exportFileName = typeof(TConsumption).Name;
    
    public TNotesService NotesService { get; } = notesService;
    public TChartService ChartService => NotesService.ChartService;
    
    [RelayCommand]
    private void Remove(TConsumption consumption)
    {
        NotesService.RemoveNote(consumption);
    }

    protected async Task ImportFromStream(Stream stream)
    {
        var data = await DataExporterImporter<TConsumption>.ImportAsync(stream);
        await NotesService.ImportDataAsync(data);
    }
    
    protected async Task<string> WriteToFile(string folderPath)
    {
        var filename = $"{_exportFileName}_{DateTime.UtcNow:dd-MM-yyyy}.json";
        var filePath = Path.Combine(folderPath, filename);

        await DataExporterImporter<TConsumption>.ExportAsync(filePath, NotesService.Consumptions);
        
        return filePath;
    }
}