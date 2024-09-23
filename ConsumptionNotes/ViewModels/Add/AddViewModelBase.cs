namespace ConsumptionNotes.ViewModels.Add;

public abstract partial class AddViewModelBase : ViewModelBase
{
    [ObservableProperty] private DateTimeOffset _selectedDate = DateTimeOffset.UtcNow;
}