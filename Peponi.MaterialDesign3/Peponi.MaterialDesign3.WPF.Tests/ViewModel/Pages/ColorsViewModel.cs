using Peponi.SourceGenerators;

namespace Peponi.MaterialDesign3.WPF.Tests.ViewModel.Pages;

[NotifyInterface]
public partial class ColorsViewModel
{
    [Command]
    private void Light()
    {
        MaterialTheme.SetColorMode(Colors.ColorMode.Light);
    }

    [Command]
    private void Dark()
    {
        MaterialTheme.SetColorMode(Colors.ColorMode.Dark);
    }

    [Command]
    private void Auto()
    {
        MaterialTheme.SetColorMode(Colors.ColorMode.Auto);
    }
}