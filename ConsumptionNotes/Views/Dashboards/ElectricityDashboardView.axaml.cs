namespace ConsumptionNotes.Views.Dashboards;

public partial class ElectricityDashboardView : UserControl
{
    public ElectricityDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityDashboardViewModel>();
    }
}