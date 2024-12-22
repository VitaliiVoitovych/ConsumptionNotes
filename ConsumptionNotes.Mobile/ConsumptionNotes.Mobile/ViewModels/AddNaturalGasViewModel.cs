using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsumptionNotes.Application.Services.Notes;
using ConsumptionNotes.Domain.Exceptions;
using ConsumptionNotes.Domain.Models;

namespace ConsumptionNotes.Mobile.ViewModels;

public partial class AddNaturalGasViewModel(NaturalGasNotesService notesService) : ObservableObject
{
    [ObservableProperty] private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now);
    [ObservableProperty] private double _cubicMeterConsumed;
    [ObservableProperty] private decimal _cubicMeterPrice = 7.95689m;

    [RelayCommand]
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..", true);
    }

    [RelayCommand]
    private async Task Add()
    {
        var amountToPay = Convert.ToDecimal(CubicMeterConsumed) * CubicMeterPrice;

        var consumption = new NaturalGasConsumption(SelectedDate, CubicMeterConsumed, amountToPay);
        try
        {
            InvalidConsumptionDataException.ThrowIfDateInvalid(consumption);
            notesService.AddNote(consumption);
            UpdateDate();
        }
        catch (DuplicateConsumptionNoteException)
        {
            await Shell.Current.DisplayAlert("Помилка!", "Запис про цей місяць вже є", "Зрозуміло");
        }
        catch (InvalidConsumptionDataException)
        {
            await Shell.Current.DisplayAlert("Помилка!", "Не можна додавати запис \r\nпро поточний чи майбутній місяць", "Зрозуміло");
        }
    }

    private void UpdateDate() => SelectedDate = SelectedDate.AddMonths(1);
}
