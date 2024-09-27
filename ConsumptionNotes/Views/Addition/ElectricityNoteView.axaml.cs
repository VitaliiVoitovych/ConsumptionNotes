namespace ConsumptionNotes.Views.Addition;

public partial class ElectricityNoteView : UserControl
{
    public ElectricityNoteView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityNoteViewModel>();
    }
}