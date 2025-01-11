namespace ConsumptionNotes.Desktop.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<HomeViewModel>();
    }
}