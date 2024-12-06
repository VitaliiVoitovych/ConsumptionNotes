using ConsumptionNotes.Desktop.ViewModels.Dashboards;

namespace ConsumptionNotes.Desktop.Views.Dashboards;

public partial class NaturalGasDashboardView : UserControl
{
    public NaturalGasDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasDashboardViewModel>();
    }

    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);

        var newHeight = e.NewSize.Height;
        var height = newHeight > 630 ? newHeight / 2 - 10 : Bounds.Height;

        ConsumptionChart.Height = AmountToPayChart.Height = height;
    }
}