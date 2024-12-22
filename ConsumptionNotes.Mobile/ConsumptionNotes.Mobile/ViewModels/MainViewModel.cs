using CommunityToolkit.Mvvm.ComponentModel;
using ConsumptionNotes.Application.Services.Notes;

namespace ConsumptionNotes.Mobile.ViewModels;

public class MainViewModel : ObservableObject
{
    public ElectricityNotesService ElectricityNotesService { get; }
    public NaturalGasNotesService NaturalGasNotesService { get; }

    public MainViewModel(ElectricityNotesService electricityNotesService,
        NaturalGasNotesService naturalGasNotesService)
    {
        ElectricityNotesService = electricityNotesService;
        NaturalGasNotesService = naturalGasNotesService;

        Task.Run(async () =>
        {
            await ElectricityNotesService.LoadDataAsync();
            await NaturalGasNotesService.LoadDataAsync();
        });
    }
}