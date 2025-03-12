using ConsumptionNotes.Mobile.Views;
using ConsumptionNotes.Mobile.ViewModels;

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

        foreach (ChartWidget chartWidget in Charts.ItemsSource)
        {
            chartWidget.UpdateChart();
        }
    }

    private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CalculatorPage), true);
    }
}