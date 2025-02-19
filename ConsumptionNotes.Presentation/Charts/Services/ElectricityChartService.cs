using ConsumptionNotes.Presentation.Charts.Styles;
using ConsumptionNotes.Presentation.Charts.Utils;

namespace ConsumptionNotes.Presentation.Charts.Services;

public class ElectricityChartService : ConsumptionChartServiceBase<ElectricityConsumption>
{
    // Series values
    private readonly ObservableCollection<int> _dayKilowattConsumedValues = [];
    private readonly ObservableCollection<int> _nightKilowattConsumedValues = [];

    public IEnumerable<ISeries<int>> KilowattConsumedSeries =>
    [
        LineSeriesUtil.FromCollection(_dayKilowattConsumedValues, Colors.DaySeriesColor, "День"),
        LineSeriesUtil.FromCollection(_nightKilowattConsumedValues, Colors.NightSeriesColor, "Ніч")
    ];

    public override void ClearValues()
    {
        base.ClearValues();
        
        _dayKilowattConsumedValues.Clear();
        _nightKilowattConsumedValues.Clear();
    }

    public override void AddValues(ElectricityConsumption consumption)
    {
        base.AddValues(consumption);
        
        _dayKilowattConsumedValues.Add(consumption.DayKilowattConsumed);
        _nightKilowattConsumedValues.Add(consumption.NightKilowattConsumed);
    }

    public override void InsertValues(int index, ElectricityConsumption consumption)
    {
        base.InsertValues(index, consumption);
        
        _dayKilowattConsumedValues.Insert(index, consumption.DayKilowattConsumed);
        _nightKilowattConsumedValues.Insert(index, consumption.NightKilowattConsumed);
    }

    public override void RemoveValues(int index)
    {
        base.RemoveValues(index);
        
        _dayKilowattConsumedValues.RemoveAt(index);
        _nightKilowattConsumedValues.RemoveAt(index);
    }

    public override void UpdateValues(int index, ElectricityConsumption consumption)
    {
        base.UpdateValues(index, consumption);

        _dayKilowattConsumedValues[index] = consumption.DayKilowattConsumed;
        _nightKilowattConsumedValues[index] = consumption.NightKilowattConsumed;
    }
}