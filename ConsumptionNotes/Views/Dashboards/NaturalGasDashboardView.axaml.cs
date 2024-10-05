namespace ConsumptionNotes.Views.Dashboards;

public partial class NaturalGasDashboardView : UserControl
{
    public NaturalGasDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasDashboardViewModel>();
    }
}