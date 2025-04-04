namespace ConsumptionNotes.Desktop.Views.Adding;

public partial class NaturalGasAddingView : 
    ConsumptionAddingView<NaturalGasConsumption, ObservableNaturalGasConsumption>
{
    public NaturalGasAddingView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasAddingViewModel>();
    }
}