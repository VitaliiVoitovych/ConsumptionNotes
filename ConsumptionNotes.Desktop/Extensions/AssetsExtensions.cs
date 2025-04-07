using Avalonia.Platform;
using Avalonia.Svg.Skia;

namespace ConsumptionNotes.Desktop.Extensions;

public static class AssetsExtensions
{
    public static SvgImage LoadSvgFromAssets(string uriString)
    {
        using var stream = AssetLoader.Open(new Uri(uriString));
        var svg = SvgSource.LoadFromStream(stream);
        return new SvgImage { Source = svg };
    }
}