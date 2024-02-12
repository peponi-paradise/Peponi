using Peponi.MaterialDesign3.WPF.Colors;
using Peponi.MaterialDesign3.WPF.Fonts;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF;

public static class ThemeProvider
{
    /// <inheritdoc cref="ColorProvider.UseWindowsAccentColor(ColorMode)"/>
    public static void UseWindowsAccentColor(ColorMode colorMode = ColorMode.Auto) => ColorProvider.UseWindowsAccentColor(colorMode);

    /// <inheritdoc cref="ColorProvider.SetColors(Color, ColorMode)"/>
    public static void SetColors(Color color, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetColors(color, colorMode);

    /// <inheritdoc cref="ColorProvider.SetColors(Color, Color, Color, ColorMode)"/>
    public static void SetColors(Color primary, Color secondary, Color tertiary, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetColors(primary, secondary, tertiary, colorMode);

    /// <inheritdoc cref="ColorProvider.SetColors(string, ColorMode)"/>
    public static bool SetColors(string xamlPath, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetColors(xamlPath, colorMode);

    /// <inheritdoc cref="ColorProvider.SetColors(Dictionary{string, object}, ColorMode)"/>
    public static bool SetColors(Dictionary<string, object> collection, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetColors(collection, colorMode);

    /// <inheritdoc cref="ColorProvider.SetColorMode(ColorMode)"/>
    public static void SetColorMode(ColorMode colorMode) => ColorProvider.SetColorMode(colorMode);

    /// <inheritdoc cref="FontProvider.AddFontFamily(string)"/>
    public static bool AddFontFamily(string fontFamily) => FontProvider.AddFontFamily(fontFamily);

    /// <inheritdoc cref="FontProvider.AddFontFamily(string, string)"/>
    public static bool AddFontFamily(string fontFamily, string uri) => FontProvider.AddFontFamily(fontFamily, uri);

    /// <inheritdoc cref="FontProvider.SetFontFamily(string)"/>
    public static bool SetFontFamily(string fontFamily) => FontProvider.SetFontFamily(fontFamily);

    /// <inheritdoc cref="FontProvider.SetFontOption(string,FontOption)"/>
    public static bool SetFontOption(string key, FontOption option) => FontProvider.SetFontOption(key, option);

    /// <inheritdoc cref="FontProvider.SetFontOption(string)"/>
    public static bool SetFontOption(string xamlPath) => FontProvider.SetFontOption(xamlPath);

    /// <inheritdoc cref="FontProvider.SetFontOption(Dictionary{string, FontOption})"/>
    public static bool SetFontOption(Dictionary<string, FontOption> collection) => FontProvider.SetFontOption(collection);
}