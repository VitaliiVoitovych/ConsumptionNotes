using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ConsumptionNotes.Services.Notes;

public partial class NaturalGasNotesService : BaseNotesService<NaturalGasConsumption, NaturalGasChartService>
{
    [ObservableProperty] private decimal _averageAmount;
    [ObservableProperty] private double _averageCubicMeterConsumed;
    
    public ObservableCollection<NaturalGasConsumption> NaturalGasConsumptions { get; }
    
    public NaturalGasNotesService(NaturalGasChartService chartService) : base(chartService)
    {
        NaturalGasConsumptions = [];
    }

    public override void AddNote(NaturalGasConsumption note)
    {
        if (NaturalGasConsumptions.Any(n => EqualsYearAndMonth(n.Date, note.Date)))
            throw new ArgumentException("Запис про цей місяць вже є");

        var lastConditionNote = NaturalGasConsumptions.LastOrDefault(n => n.Date < note.Date);
        var index = NaturalGasConsumptions.IndexOf(lastConditionNote!) + 1;
        
        NaturalGasConsumptions.Insert(index, note);
        ChartService.AddValues(index, note);
        
        UpdateAverageValues();
    }

    public override void RemoveNote(NaturalGasConsumption note)
    {
        var index = NaturalGasConsumptions.IndexOf(note);

        NaturalGasConsumptions.RemoveAt(index);
        ChartService.RemoveValues(index);
        
        UpdateAverageValues();
    }

    protected override void UpdateAverageValues()
    {
        if (NaturalGasConsumptions.Count > 0)
        {
            AverageAmount = NaturalGasConsumptions.Average(e => e.AmountToPay);
            AverageCubicMeterConsumed = NaturalGasConsumptions.Average(e => e.CubicMeterConsumed);
        }
        else
        {
            AverageAmount = 0.0m;
            AverageCubicMeterConsumed = 0.0;
        }
    }
}