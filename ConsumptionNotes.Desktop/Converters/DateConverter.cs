using Avalonia.Data.Converters;

namespace ConsumptionNotes.Desktop.Converters;

public class DateConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var date = (DateOnly)value!;
        return new DateTimeOffset(date, TimeOnly.MinValue, TimeSpan.Zero);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var dateTimeOffset = (DateTimeOffset)value!;
        return DateOnly.FromDateTime(dateTimeOffset.DateTime);
    }
}