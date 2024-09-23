using FluentAvalonia.UI.Controls;

namespace ConsumptionNotes.ViewModels.Add;

public partial class ElectricityAddViewModel(ElectricityNotesService notesService) : AddViewModelBase
{
    [ObservableProperty] private int _dayKilowattConsumed;
    [ObservableProperty] private int _nightKilowattConsumed;
    [ObservableProperty] private decimal _kilowattPerHourPrice = 4.32m;

    [RelayCommand]
    private async Task Add()
    {
        var amountToPay = DayKilowattConsumed * KilowattPerHourPrice +
                          NightKilowattConsumed * (KilowattPerHourPrice * 0.5m);

        var consumption = new ElectricityConsumption(DateOnly.FromDateTime(SelectedDate.DateTime), DayKilowattConsumed,
            NightKilowattConsumed, amountToPay);

        try
        {
            notesService.AddNote(consumption);
            SelectedDate = SelectedDate.AddMonths(1);
        }
        catch (ArgumentException ex)
        {
            var contentDialog = new ContentDialog()
            {
                Title = "Помилка!",
                Content = ex.Message,
                CloseButtonText = "Зрозуміло"
            };

            await contentDialog.ShowAsync();
        }
    }
}