using Avalonia.Controls.Primitives;

namespace ConsumptionNotes.Desktop.Views.Dashboards;

public partial class NaturalGasDashboardView : UserControl
{
    private ScrollBar? _dataGridVerticalScrollbar;
    public NaturalGasDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasDashboardViewModel>();
        
        NaturalGasDataGrid.TemplateApplied += (_, e) =>
        {
            _dataGridVerticalScrollbar = e.NameScope.Find<ScrollBar>("PART_VerticalScrollbar");
        };
        NaturalGasDataGrid.LayoutUpdated += (_, _) =>
        {
            if (_dataGridVerticalScrollbar!.IsVisible)
                NaturalGasDataGrid.Classes.Add("VerticalScrollBarVisible");
            else
                NaturalGasDataGrid.Classes.Remove("VerticalScrollBarVisible");
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