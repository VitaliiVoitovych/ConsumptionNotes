namespace ConsumptionNotes.Views;

public partial class ElectricityDashboardView : UserControl
{
    public ElectricityDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityDashboardViewModel>();
    }
}