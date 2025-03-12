using Avalonia.Controls.Primitives;

namespace ConsumptionNotes.Desktop.Views.Dashboards;

public partial class ElectricityDashboardView : UserControl
{
    private ScrollBar? _dataGridVerticalScrollbar;
    public ElectricityDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityDashboardViewModel>();

        ElectricityDataGrid.TemplateApplied += (_, e) =>
        {
            _dataGridVerticalScrollbar = e.NameScope.Find<ScrollBar>("PART_VerticalScrollbar");
        };
        ElectricityDataGrid.LayoutUpdated += (_, _) =>
        {
            if (_dataGridVerticalScrollbar!.IsVisible)
                ElectricityDataGrid.Classes.Add("VerticalScrollBarVisible");
            else
                ElectricityDataGrid.Classes.Remove("VerticalScrollBarVisible");
        };
    }

    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);

        var newHeight = e.NewSize.Height;
        var height = newHeight > 630 ? newHeight / 2 - 20 : Bounds.Height - 20;

        ConsumptionChart.Height = AmountToPayChart.Height = height;
    }
}