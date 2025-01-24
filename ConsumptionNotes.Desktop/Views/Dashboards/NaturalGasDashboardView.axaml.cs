using System.Diagnostics;

namespace ConsumptionNotes.Desktop.Views.Dashboards;

public partial class NaturalGasDashboardView : UserControl
{
    public NaturalGasDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasDashboardViewModel>();

        NaturalGasDataGrid.GotFocus += (s, e) =>
        {
            NaturalGasDataGrid.UpdateLayout();
            OnLoaded(e);
        };
    }

    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);

        var newHeight = e.NewSize.Height;
        var height = newHeight > 630 ? newHeight / 2 - 10 : Bounds.Height;

        ConsumptionChart.Height = AmountToPayChart.Height = height;
    }
}