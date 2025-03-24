namespace ConsumptionNotes.Desktop.Views.Dashboards;

public partial class ElectricityDashboardView : DashboardViewBase
{
    public ElectricityDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityDashboardViewModel>();
        
        ElectricityDataGrid.TemplateApplied += GetVerticalScrollBar;
        ElectricityDataGrid.LayoutUpdated += UpdateDataGridVerticalScrollBarStyle;
    }

    protected override void UpdateChartWidgetsHeight(double height)
    {
        ConsumptionChart.Height = AmountToPayChart.Height = height;
    }
}