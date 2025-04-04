namespace ConsumptionNotes.Desktop.Views.Editing;

public partial class NaturalGasEditingView : 
    ConsumptionEditingView<NaturalGasConsumption, ObservableNaturalGasConsumption>
{
    public NaturalGasEditingView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasEditingViewModel>();
    }
}