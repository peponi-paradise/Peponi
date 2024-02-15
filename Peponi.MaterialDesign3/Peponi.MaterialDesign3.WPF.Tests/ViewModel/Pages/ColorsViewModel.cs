using Peponi.SourceGenerators;

namespace Peponi.MaterialDesign3.WPF.Tests.ViewModel.Pages;

[NotifyInterface]
public partial class ColorsViewModel
{
    [Command]
    private void Light()
    {
        MaterialTheme.Current.ColorMode = ColorMode.Light;
    }

    [Command]
    private void Dark()
    {
        MaterialTheme.Current.ColorMode = ColorMode.Dark;
    }

    [Command]
    private void Auto()
    {
        MaterialTheme.Current.ColorMode = ColorMode.Auto;
    }
}