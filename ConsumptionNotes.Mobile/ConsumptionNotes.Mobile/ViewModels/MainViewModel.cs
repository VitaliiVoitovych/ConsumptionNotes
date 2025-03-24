using ConsumptionNotes.Presentation.ViewModels;

namespace ConsumptionNotes.Mobile.ViewModels;

public class MainViewModel(
    ObservableElectricityNotesService electricityNotesService,
    ObservableNaturalGasNotesService naturalGasNotesService)
    : MainViewModelBase(electricityNotesService, naturalGasNotesService)
{
    public AsyncRelayCommand OpenCalculatorPage { get; } = new GoToCommand(nameof(CalculatorPage));
}