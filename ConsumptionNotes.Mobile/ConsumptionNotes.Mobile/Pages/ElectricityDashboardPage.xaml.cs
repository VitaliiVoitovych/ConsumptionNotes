namespace ConsumptionNotes.Mobile.Pages;

public partial class ElectricityDashboardPage : ContentPage
{
    public ElectricityDashboardPage(ElectricityDashboardViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}