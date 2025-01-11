namespace ConsumptionNotes.Desktop.Views.Adding;

public partial class ElectricityNoteView : UserControl
{
    public ElectricityNoteView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<ElectricityAddViewModel>();
    }
}