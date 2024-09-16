namespace ConsumptionNotes.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();

        DataContext = App.Host.Services.GetRequiredService<HomeViewModel>();
    }
}