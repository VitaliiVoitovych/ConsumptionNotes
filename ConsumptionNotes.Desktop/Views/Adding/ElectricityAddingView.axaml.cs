namespace ConsumptionNotes.Desktop.Views.Adding;

public partial class ElectricityAddingView : UserControl
{
    public ElectricityAddingView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityAddingViewModel>();
    }
}