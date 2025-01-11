namespace ConsumptionNotes.Desktop.Views.Adding;

public partial class NaturalGasAddingView : UserControl
{
    public NaturalGasAddingView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasAddingViewModel>();
    }
}