namespace ConsumptionNotes.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<HomeViewModel>();
    }
}