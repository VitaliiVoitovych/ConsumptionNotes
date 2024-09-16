namespace ConsumptionNotes.Views;

public partial class ElectricityView : UserControl
{
    public ElectricityView()
    {
        InitializeComponent();

        DataContext = App.Host.Services.GetRequiredService<ElectricityViewModel>();
    }
}