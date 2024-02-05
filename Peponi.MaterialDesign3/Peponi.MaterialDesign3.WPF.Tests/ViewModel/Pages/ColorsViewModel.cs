using Peponi.SourceGenerators;

namespace Peponi.MaterialDesign3.WPF.Tests.ViewModel.Pages;

[NotifyInterface]
public partial class ColorsViewModel
{
    [Command]
    private void Light()
    {
        ThemeProvider.SetColorMode(Colors.ColorMode.Light);
    }

    [Command]
    private void Dark()
    {
        ThemeProvider.SetColorMode(Colors.ColorMode.Dark);
    }

    [Command]
    private void Auto()
    {
        ThemeProvider.SetColorMode(Colors.ColorMode.Auto);
    }
}