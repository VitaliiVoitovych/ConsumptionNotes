using ConsumptionNotes.Presentation.ViewModels;

namespace ConsumptionNotes.Desktop.ViewModels;

public partial class MainViewModel(
    ObservableElectricityNotesService electricityNotesService,
    ObservableNaturalGasNotesService naturalGasNotesService)
    : BaseMainViewModel(electricityNotesService, naturalGasNotesService)
{
    [RelayCommand]
    private async Task OpenCalculatorDialog()
    {
        var calculatorView = Ioc.Default.GetRequiredService<CalculatorView>();
        await calculatorView.ShowContentDialog("Калькулятор", "ОК");
    }
}