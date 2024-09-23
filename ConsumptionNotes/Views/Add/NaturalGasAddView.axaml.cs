namespace ConsumptionNotes.Views.Add;

public partial class NaturalGasAddView : UserControl
{
    public NaturalGasAddView(NaturalGasAddViewModel vm)
    {
        InitializeComponent();

        DataContext = vm;
    }
}