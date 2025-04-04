namespace ConsumptionNotes.Desktop.Views.Adding;

public partial class ElectricityAddingView : 
    ConsumptionAddingView<ElectricityConsumption, ObservableElectricityConsumption>
{
    public ElectricityAddingView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityAddingViewModel>();
    }
}