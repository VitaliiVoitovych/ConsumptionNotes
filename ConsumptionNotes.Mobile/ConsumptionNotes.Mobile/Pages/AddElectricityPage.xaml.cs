using ConsumptionNotes.Mobile.ViewModels.Addition;

namespace ConsumptionNotes.Mobile.Pages;

public partial class AddElectricityPage : ContentPage
{
	public AddElectricityPage(AddElectricityViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}