﻿using Android.Views;
using Android.Widget;
using AndroidX.CoordinatorLayout.Widget;
using ConsumptionNotes.Mobile.Views;
using Google.Android.Material.BottomSheet;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace ConsumptionNotes.Mobile.Droid.Handlers;

public class BottomSheetHandler : ViewHandler<BottomSheet, CoordinatorLayout>
{

    public static IPropertyMapper<BottomSheet, BottomSheetHandler> PropertyMapper =
        new PropertyMapper<BottomSheet, BottomSheetHandler>()
        {
            [nameof(BottomSheet.Content)] = MapContent,
            [nameof(BottomSheet.BottomSheetContent)] = MapBottomSheetContent,
            [nameof(BottomSheet.BottomSheetBackgroundColor)] = MapBottomSheetBackgroundColor,
            [nameof(BottomSheet.DragHandleColor)] = MapDragHandleColor,
        };

    public BottomSheetHandler() : base(PropertyMapper) { }
    
    public BottomSheetHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
    {
    }

    private CoordinatorLayout CoordinatorLayout { get; set; }
    private LinearLayout LinearLayout { get; set; }
    private BottomSheetDragHandleView DragHandle { get; set; }
    
    protected override CoordinatorLayout CreatePlatformView()
    {
        CoordinatorLayout = new CoordinatorLayout(Context);

        var metrics = Context.Resources!.DisplayMetrics;
        
        LinearLayout = new LinearLayout(Context)
        {
            LayoutParameters = new CoordinatorLayout.LayoutParams(
                metrics!.WidthPixels,
                metrics.HeightPixels)
            {
                Behavior = new BottomSheetBehavior()
            },
            Orientation = Orientation.Vertical
        };
        
        LinearLayout.SetGravity(GravityFlags.CenterHorizontal);
        CoordinatorLayout.AddView(LinearLayout);
        
        var behavior = BottomSheetBehavior.From(LinearLayout);
        behavior.State = BottomSheetBehavior.StateCollapsed;
        behavior.Hideable = false;
        behavior.PeekHeight = (int)((metrics.HeightPixels - 264) * 0.65) - 92;

        var borderDrawable = new BorderDrawable(Context);
        borderDrawable.SetCornerRadius(new CornerRadius(25, 25, 0, 0));
        LinearLayout.Background = borderDrawable;

        var dragViewBorder = new BorderDrawable(Context);
        dragViewBorder.SetCornerRadius(new CornerRadius(25));
        
        DragHandle = new BottomSheetDragHandleView(Context)
        {
            LayoutParameters = new LinearLayout.LayoutParams(
                (int)Context.ToPixels(35),
                (int)Context.ToPixels(6))
            {
                TopMargin = 25,
                BottomMargin = 25
            },
            Background = dragViewBorder,
        };
        
        LinearLayout.AddView(DragHandle);
        
        return CoordinatorLayout;
    }
    
    private static void MapBottomSheetContent(BottomSheetHandler handler, BottomSheet bottomSheet)
    {
        handler.LinearLayout.AddView(bottomSheet.BottomSheetContent.ToPlatform(handler.MauiContext!),
            new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,ViewGroup.LayoutParams.MatchParent));
    }

    private static void MapContent(BottomSheetHandler handler, BottomSheet bottomSheet)
    {
        var metrics = handler.Context.Resources!.DisplayMetrics;
        var height = Convert.ToInt32(metrics!.HeightPixels * 0.35);
        
        handler.CoordinatorLayout.AddView(bottomSheet.Content.ToPlatform(handler.MauiContext!), 0,
            new ViewGroup.LayoutParams(metrics.WidthPixels, height));
    }
    
    private static void MapBottomSheetBackgroundColor(BottomSheetHandler handler, BottomSheet bottomSheet)
    {
        ((BorderDrawable)handler.LinearLayout.Background!).SetBackgroundColor(bottomSheet.BottomSheetBackgroundColor.ToPlatform());
    }
    
    private static void MapDragHandleColor(BottomSheetHandler handler, BottomSheet bottomSheet)
    {
        ((BorderDrawable)handler.DragHandle.Background!).SetBackgroundColor(bottomSheet.DragHandleColor.ToPlatform());
    }
}