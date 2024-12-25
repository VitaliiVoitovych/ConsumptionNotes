using ConsumptionNotes.Mobile.ViewModels;

namespace ConsumptionNotes.Mobile.Pages;

public partial class AddElectricityPage : ContentPage
{
	public AddElectricityPage(AddElectricityViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}