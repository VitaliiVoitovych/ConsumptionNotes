using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ConsumptionNotes.Services.Notes;

public partial class ElectricityNotesService : BaseNotesService<ElectricityConsumption, ElectricityChartService>
{
    [ObservableProperty] private decimal _averageAmount;
    [ObservableProperty] private double _averageKilowattConsumed;
    
    public ObservableCollection<ElectricityConsumption> ElectricityConsumptions { get; }
    
    public ElectricityNotesService(ElectricityChartService chartService) 
        : base(chartService)
    {
        ElectricityConsumptions = [];
    }

    public override void AddNote(ElectricityConsumption note)
    {
        if (ElectricityConsumptions.Any(n => EqualsYearAndMonth(n.Date, note.Date)))
            throw new ArgumentException("Запис про цей місяць вже є");

        var lastConditionNote = ElectricityConsumptions.LastOrDefault(n => n.Date < note.Date);
        var index = ElectricityConsumptions.IndexOf(lastConditionNote!) + 1;
        
        ElectricityConsumptions.Insert(index, note);
        ChartService.AddValues(index, note);
        
        UpdateAverageValues();
    }

    public override void RemoveNote(ElectricityConsumption note)
    {
        var index = ElectricityConsumptions.IndexOf(note);
        ElectricityConsumptions.RemoveAt(index);
        ChartService.RemoveValues(index);
        
        UpdateAverageValues();
    }

    protected override void UpdateAverageValues()
    {
        if (ElectricityConsumptions.Count > 0)
        {
            AverageAmount = ElectricityConsumptions.Average(e => e.AmountToPay);
            AverageKilowattConsumed = ElectricityConsumptions.Average(e => e.DayKilowattConsumed + e.NightKilowattConsumed);
        }
        else
        {
            AverageAmount = 0.0m;
            AverageKilowattConsumed = 0.0;
        }
    }
}