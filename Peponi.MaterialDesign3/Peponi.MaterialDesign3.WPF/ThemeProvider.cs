using Peponi.MaterialDesign3.WPF.Colors;
using Peponi.MaterialDesign3.WPF.Fonts;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF;

public static class ThemeProvider
{
    public static void UseWindowsAccentColor(ColorMode colorMode = ColorMode.Auto) => ColorProvider.UseWindowsAccentColor(colorMode);

    public static void SetColor(Color color, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetColor(color, colorMode);

    public static void SetColor(Color primary, Color secondary, Color tertiary, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetColor(primary, secondary, tertiary, colorMode);

    public static bool SetColors(string xamlPath, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetColors(xamlPath, colorMode);

    public static bool SetColors(Dictionary<string, object> collection, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetColors(collection, colorMode);

    public static void SetColorMode(ColorMode colorMode) => ColorProvider.SetColorMode(colorMode);

    public static bool AddFontFamily(string fontFamily) => FontProvider.AddFontFamily(fontFamily);

    public static bool AddFontFamily(string fontFamily, string uri) => FontProvider.AddFontFamily(fontFamily, uri);

    public static bool SetFontFamily(string fontFamily) => FontProvider.SetFontFamily(fontFamily);

    public static bool ChangeFontOption(string key, FontOption option) => FontProvider.ChangeFontOption(key, option);
}