using ConsumptionNotes.Desktop.ViewModels.Editing;

namespace ConsumptionNotes.Desktop.Views.Editing;

public partial class NaturalGasEditingView : UserControl
{
    public NaturalGasEditingView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasEditingViewModel>();
    }
}