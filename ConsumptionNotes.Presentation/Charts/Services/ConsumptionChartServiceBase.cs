using ConsumptionNotes.Presentation.Charts.Styles;
using ConsumptionNotes.Presentation.Charts.Utils;

namespace ConsumptionNotes.Presentation.Charts.Services;

public abstract class ConsumptionChartServiceBase<TConsumption>
    where TConsumption : BaseConsumption
{
    // Series values
    private readonly ObservableCollection<decimal> _amountToPayValues = [];
    private readonly ObservableCollection<string> _dateLabels = [];

    public IEnumerable<ISeries<decimal>> AmountsToPaySeries =>
    [
        LineSeriesUtil.FromCollection(_amountToPayValues, Colors.AmountToPaySeriesColor)
    ];

    public IEnumerable<Axis> AmountToPayYAxes =>
    [
        AxisUtil.LabelerAxis(d => d.ToString("F2"))
    ];

    public IEnumerable<Axis> ConsumedYAxes =>
    [
        AxisUtil.LabelerAxis()
    ];

    public IEnumerable<Axis> DateXAxes =>
    [
        new()
        {
            Labels = _dateLabels,
            MaxLimit = Constants.MaxXAxisLabels,
            LabelsPaint = Paints.AxisLabelsPaint
        }
    ];

    public virtual void ClearValues()
    {
        _dateLabels.Clear();
        _amountToPayValues.Clear();
    }
    
    public virtual void AddValues(TConsumption consumption)
    {
        _dateLabels.Add(consumption.Date.ToString(Constants.DateFormat));
        _amountToPayValues.Add(consumption.AmountToPay);
    }

    public virtual void InsertValues(int index, TConsumption consumption)
    {
        _dateLabels.Insert(index, consumption.Date.ToString(Constants.DateFormat));
        _amountToPayValues.Insert(index, consumption.AmountToPay);
    }

    public virtual void RemoveValues(int index)
    {
        _dateLabels.RemoveAt(index);
        _amountToPayValues.RemoveAt(index);
    }

    public virtual void UpdateValues(int index, TConsumption consumption)
    {
        _amountToPayValues[index] = consumption.AmountToPay;
    }
}