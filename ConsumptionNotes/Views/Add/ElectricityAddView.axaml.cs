namespace ConsumptionNotes.Views.Add;

public partial class ElectricityAddView : UserControl
{
    public ElectricityAddView(ElectricityAddViewModel vm)
    {
        InitializeComponent();

        DataContext = vm;
    }
}