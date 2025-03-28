﻿namespace ConsumptionNotes.Domain.Models;

public class ElectricityConsumption(
    DateOnly date,
    int dayKilowattConsumed,
    int nightKilowattConsumed,
    decimal amountToPay)
    : ConsumptionBase(date, amountToPay)
{
    public int DayKilowattConsumed { get; set; } = dayKilowattConsumed;
    public int NightKilowattConsumed { get; set; } = nightKilowattConsumed;
}