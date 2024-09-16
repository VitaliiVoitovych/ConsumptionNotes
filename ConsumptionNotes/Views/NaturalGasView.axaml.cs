namespace ConsumptionNotes.Views;

public partial class NaturalGasView : UserControl
{
    public NaturalGasView()
    {
        InitializeComponent();

        DataContext = App.Host.Services.GetRequiredService<NaturalGasViewModel>();
    }
}