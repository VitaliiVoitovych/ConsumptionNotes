namespace ConsumptionNotes.Desktop.Views.Editing;

public partial class ElectricityEditingView : UserControl
{
    public ElectricityEditingView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityEditingViewModel>();
    }
}