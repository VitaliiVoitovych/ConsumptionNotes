﻿using PaymentCalculator = ConsumptionNotes.Infrastructure.PaymentCalculator;

namespace ConsumptionNotes.Presentation.ViewModels;

public partial class CalculatorViewModel : ViewModelBase
{
    private int _dayKilowattConsumed;
    public int DayKilowattConsumed
    {
        get => _dayKilowattConsumed;
        set => SetPropertyAndUpdateAmount(ref _dayKilowattConsumed, value, UpdateElectricityAmount);
    }
    
    private int _nightKilowattConsumed;
    public int NightKilowattConsumed
    {
        get => _nightKilowattConsumed;
        set => SetPropertyAndUpdateAmount(ref _nightKilowattConsumed, value, UpdateElectricityAmount);
    }
    
    private decimal _kilowattHourPrice = ConsumptionTariffs.KilowattHourPrice;
    public decimal KilowattHourPrice
    {
        get => _kilowattHourPrice;
        set => SetPropertyAndUpdateAmount(ref _kilowattHourPrice, value, UpdateElectricityAmount);
    }

    private double _cubicMeterConsumed;
    public double CubicMeterConsumed
    {
        get => _cubicMeterConsumed;
        set => SetPropertyAndUpdateAmount(ref _cubicMeterConsumed, value, UpdateNaturalGasAmount);
    }
    
    private decimal _cubicMeterPrice = ConsumptionTariffs.CubicMeterPrice;
    public decimal CubicMeterPrice
    {
        get => _cubicMeterPrice;
        set => SetPropertyAndUpdateAmount(ref _cubicMeterPrice, value, UpdateNaturalGasAmount);
    }
    
    
    [ObservableProperty] private decimal _electricityAmountToPay;
    [ObservableProperty] private decimal _naturalGasAmountToPay;

    private void SetPropertyAndUpdateAmount<T>(ref T field, T value, Action updateMethod)
    {
        SetProperty(ref field, value);
        
        updateMethod.Invoke();
    }
    
    private void UpdateElectricityAmount()
    {
        ElectricityAmountToPay =
            PaymentCalculator.CalculateElectricityPayment(DayKilowattConsumed, NightKilowattConsumed,
                KilowattHourPrice);
    }

    private void UpdateNaturalGasAmount()
    {
        NaturalGasAmountToPay = PaymentCalculator.CalculateNaturalGasPayment(CubicMeterConsumed, CubicMeterPrice);
    }
}