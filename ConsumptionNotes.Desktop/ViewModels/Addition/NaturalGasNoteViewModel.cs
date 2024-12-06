using ConsumptionNotes.Application.Services.Notes;

namespace ConsumptionNotes.Desktop.ViewModels.Addition;

public partial class NaturalGasNoteViewModel
    : ConsumptionNoteViewModelBase<NaturalGasConsumption, NaturalGasNotesService>
{
    [ObservableProperty] private double _cubicMetersConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.95689m;

    public NaturalGasNoteViewModel(NaturalGasNotesService notesService)
        : base(notesService)
    {
        
    }
    
    protected override decimal CalculateAmount()
    {
        return Convert.ToDecimal(CubicMetersConsumed) * CubicMeterPrice;
    }

    protected override NaturalGasConsumption CreateConsumption()
    {
        return new NaturalGasConsumption(
            DateOnly.FromDateTime(SelectedDate.DateTime),
            CubicMetersConsumed,
            CalculateAmount());
    }
}