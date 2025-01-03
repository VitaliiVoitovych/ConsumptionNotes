using ConsumptionNotes.Mobile.ViewModels.Dashboards;

namespace ConsumptionNotes.Mobile.Pages.Dashboards;

public partial class NaturalGasDashboardPage : ContentPage
{
    public NaturalGasDashboardPage(NaturalGasDashboardViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}