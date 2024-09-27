namespace ConsumptionNotes.Views.Addition;

public partial class NaturalGasNoteView : UserControl
{
    public NaturalGasNoteView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasNoteViewModel>();
    }
}