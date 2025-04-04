namespace ConsumptionNotes.Desktop.Views.Editing;

public partial class ElectricityEditingView : 
    ConsumptionEditingView<ElectricityConsumption, ObservableElectricityConsumption>
{
    public ElectricityEditingView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityEditingViewModel>();
    }
}