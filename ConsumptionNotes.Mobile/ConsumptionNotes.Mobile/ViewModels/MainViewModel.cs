﻿using CommunityToolkit.Mvvm.ComponentModel;
using ConsumptionNotes.Application.Services.Charting;
using ConsumptionNotes.Application.Services.Notes;

namespace ConsumptionNotes.Mobile.ViewModels;

public class MainViewModel : ObservableObject
{
    public ElectricityNotesService ElectricityNotesService { get; }
    public NaturalGasNotesService NaturalGasNotesService { get; }

    public ElectricityChartService ElectricityChartService => ElectricityNotesService.ChartService;
    public NaturalGasChartService NaturalGasChartService => NaturalGasNotesService.ChartService;

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