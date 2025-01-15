using ConsumptionNotes.Application.ViewModels;

namespace ConsumptionNotes.Mobile.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        AmountToPayChart.UpdateChart();
        ConsumptionChart.UpdateChart();
    }
}