namespace ConsumptionNotes.Desktop.Views.Dashboards;

public partial class NaturalGasDashboardView : DashboardViewBase
{
    public NaturalGasDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasDashboardViewModel>();
        
        NaturalGasDataGrid.TemplateApplied += GetVerticalScrollBar;
        NaturalGasDataGrid.LayoutUpdated += UpdateDataGridVerticalScrollBarStyle;
    }

    protected override void UpdateChartWidgetsHeight(double height)
    {
        ConsumptionChart.Height = AmountToPayChart.Height = height;
    }
}