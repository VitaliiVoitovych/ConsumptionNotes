﻿using SKColor = SkiaSharp.SKColor;

namespace ConsumptionNotes.Presentation.Charts.Styles;

public static class Colors
{
    public static readonly SKColor AxisLabelsColor = SKColor.Parse("#95b5cf");
    public static readonly SKColor SeparatorColor = SKColor.Parse("#d3d3d3");
    public static readonly SKColor LegendTextColor = SKColor.Parse("#e9ecef");

    public static readonly SKColor AmountToPaySeriesColor = SKColor.Parse("#256F33");
    
    public static readonly SKColor DaySeriesColor = SKColor.Parse("#e2e38b");
    public static readonly SKColor NightSeriesColor = SKColor.Parse("#29297d");
    public static readonly SKColor GasSeriesColor = SKColor.Parse("#367fd7");

    public static readonly SKColor TooltipTextColor = SKColor.Parse("#e9ecef");
    public static readonly SKColor TooltipBackgroundColor = SKColor.Parse("#212529");
}