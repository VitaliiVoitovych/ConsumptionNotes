using ConsumptionNotes.Mobile.ViewModels.Dashboards;

namespace ConsumptionNotes.Mobile.Pages.Dashboards;

public partial class ElectricityDashboardPage : ContentPage
{
    public ElectricityDashboardPage(ElectricityDashboardViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}