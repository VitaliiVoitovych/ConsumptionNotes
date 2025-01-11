namespace ConsumptionNotes.Mobile.Pages.Adding;

public partial class ElectricityAddingPage : ContentPage
{
	public ElectricityAddingPage(ElectricityAddingViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}