namespace ConsumptionNotes.Desktop.Views.Adding;

public partial class NaturalGasNoteView : UserControl
{
    public NaturalGasNoteView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<NaturalGasAddViewModel>();
    }
}