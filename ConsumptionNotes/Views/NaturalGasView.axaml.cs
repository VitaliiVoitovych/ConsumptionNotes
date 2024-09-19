using System.Diagnostics;
using Avalonia;

namespace ConsumptionNotes.Views;

public partial class NaturalGasView : UserControl
{
    public NaturalGasView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasViewModel>();
    }
}