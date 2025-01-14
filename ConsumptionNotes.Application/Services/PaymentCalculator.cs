namespace ConsumptionNotes.Application.Services;

public static class PaymentCalculator
{
    private const decimal NightKilowattPriceMultiplier = 0.5m;
    
    public static decimal CalculateElectricityPayment(int dayKilowattConsumed, int nightKilowattConsumed, decimal kilowattPerHourPrice)
    {
        return dayKilowattConsumed * kilowattPerHourPrice +
               nightKilowattConsumed * (kilowattPerHourPrice * NightKilowattPriceMultiplier);
    }
    
    public static decimal CalculateNaturalGasPayment(double cubicMeterConsumed, decimal cubicMeterPrice)
    {
        return Convert.ToDecimal(cubicMeterConsumed) * cubicMeterPrice;
    }
}