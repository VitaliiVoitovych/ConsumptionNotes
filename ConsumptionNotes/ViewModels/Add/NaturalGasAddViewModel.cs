using ConsumptionNotes.Utils.Dialogs;

namespace ConsumptionNotes.ViewModels.Add;

public partial class NaturalGasAddViewModel(NaturalGasNotesService notesService) : AddViewModelBase
{
    [ObservableProperty] private int _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.99m;

    [RelayCommand]
    private async Task Add()
    {
        var amountToPay = CubicMeterConsumed * CubicMeterPrice;

        var consumption = new NaturalGasConsumption(DateOnly.FromDateTime(SelectedDate.DateTime), CubicMeterConsumed,
            amountToPay);

        try
        {
            notesService.AddNote(consumption);
            SelectedDate = SelectedDate.AddMonths(1);
        }
        catch (ArgumentException ex)
        {
            var messageDialog = Dialogs.CreateMessageDialog("Помилка", ex.Message);
            await messageDialog.ShowAsync();
        }
    }
}