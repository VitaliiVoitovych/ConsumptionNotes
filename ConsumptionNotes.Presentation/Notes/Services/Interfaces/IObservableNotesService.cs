﻿namespace ConsumptionNotes.Presentation.Notes.Services.Interfaces;

public interface IObservableNotesChartService<TConsumption, TObservableConsumption, TChartService> 
    : IObservableNotesService<TConsumption, TObservableConsumption>
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
    where TChartService : ConsumptionChartServiceBase<TConsumption>
{
    public TChartService ChartService { get; }
}

public interface IObservableNotesService<TConsumption, TObservableConsumption>
    where TConsumption : ConsumptionBase
    where TObservableConsumption : ObservableConsumptionBase<TConsumption>
{
    public List<TConsumption> Consumptions { get; }
    
    Task LoadDataAsync();
    Task ImportDataAsync(IAsyncEnumerable<TConsumption> data);

    void Add(TObservableConsumption observableConsumption);
    void Remove(TObservableConsumption observableConsumption);
    void Update(TObservableConsumption observableConsumption);
}