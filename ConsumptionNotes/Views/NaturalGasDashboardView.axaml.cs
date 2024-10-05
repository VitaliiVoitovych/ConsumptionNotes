using System.Diagnostics;
using Avalonia;

namespace ConsumptionNotes.Views;

public partial class NaturalGasDashboardView : UserControl
{
    public NaturalGasDashboardView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasDashboardViewModel>();
    }
}