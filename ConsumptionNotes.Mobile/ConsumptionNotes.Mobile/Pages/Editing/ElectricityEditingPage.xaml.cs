namespace ConsumptionNotes.Mobile.Pages.Editing;

public partial class ElectricityEditingPage : ContentPage
{
    public ElectricityEditingPage(ElectricityEditingViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}