﻿using ConsumptionNotes.Desktop.ViewModels;

namespace ConsumptionNotes.Desktop.Views;

public partial class CalculatorView : UserControl
{
    public CalculatorView()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<CalculatorViewModel>();
    }
}