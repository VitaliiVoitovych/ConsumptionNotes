using ConsumptionNotes.Mobile.ViewModels;

namespace ConsumptionNotes.Mobile.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}