namespace ConsumptionNotes.Mobile.Pages.Adding;

public partial class AddElectricityPage : ContentPage
{
	public AddElectricityPage(AddElectricityViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}