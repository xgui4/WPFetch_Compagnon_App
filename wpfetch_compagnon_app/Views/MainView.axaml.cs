using Avalonia.Controls;
using System;

namespace wpfetch_compagnon_app.Views;

public partial class MainView : UserControl
{
    private const int TouchFriendlyMultiplier = 2;

    public MainView()
    {

        InitializeComponent();
        if (OperatingSystem.IsAndroid())
        {
            this.Loaded += TouchButton;
        }
        else
        {
            this.Loaded += NormalButton;
        }
    }

    private void TouchButton(object sender, EventArgs e)
    {
        double orignialWidthF = ForwardButton.DesiredSize.Width;
        double orignialHeightF = ForwardButton.DesiredSize.Height;
        double orignialWidthB = BackwardButton.DesiredSize.Width;
        double orignialHeightB = BackwardButton.DesiredSize.Height;

        ForwardButton.Width = orignialWidthF * TouchFriendlyMultiplier;
        ForwardButton.Height = orignialHeightF * TouchFriendlyMultiplier;
        BackwardButton.Width = orignialWidthB * TouchFriendlyMultiplier;
        BackwardButton.Height = orignialHeightB * TouchFriendlyMultiplier;

        NormalButton(sender, e); 
    }

    private void NormalButton(object sender, EventArgs e)
    {
        ForwardButton.Content = "->";
        BackwardButton.Content = "<-";
    }
}