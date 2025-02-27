using Avalonia.Interactivity;
using ConsumptionNotes.Presentation.ViewModels;

namespace ConsumptionNotes.Desktop.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<MainViewModel>();
    }

    private async void OpenCalculatorDialog(object? sender, RoutedEventArgs e)
    {
        var calculatorView = Ioc.Default.GetRequiredService<CalculatorView>();
        await calculatorView.ShowContentDialog("Калькулятор", "ОК");
    }
}