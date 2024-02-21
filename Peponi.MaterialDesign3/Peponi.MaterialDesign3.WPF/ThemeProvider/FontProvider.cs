using System.Windows;

namespace Peponi.MaterialDesign3.WPF.ThemeProvider;

internal class FontProvider
{
    private ResourceDictionary _resource;

    internal FontProvider(ResourceDictionary resource)
    {
        _resource = resource;

        SetDefaultFonts();
    }

    private void SetDefaultFonts()
    {
        _resource[MaterialFont.FontFamily] = _resource[MaterialFont.DefaultFontFamily.RobotoFlex];
        _resource[MaterialFont.SecondaryFontFamily] = _resource[MaterialFont.DefaultFontFamily.RobotoSerif];
        _resource[MaterialFont.TertiaryFontFamily] = _resource[MaterialFont.DefaultFontFamily.Pretendard];
    }
}