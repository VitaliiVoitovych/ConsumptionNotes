using ConsumptionNotes.Desktop.ViewModels;

namespace ConsumptionNotes.Desktop.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<MainViewModel>();
    }
}