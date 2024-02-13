using Google.MaterialColorUtilities;
using Peponi.MaterialDesign3.WPF.Colors;
using Peponi.MaterialDesign3.WPF.Fonts;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF;

public static class MaterialTheme
{
    public static Dictionary<TonalPalettes, TonalPalette> Palettes => ColorProvider.Palettes;
    public static Indexer? ThemeColors => ColorProvider.ThemeColors;

    /// <inheritdoc cref="ColorProvider.UseWindowsAccentColor(ColorMode)"/>
    public static void UseWindowsAccentColor(ColorMode colorMode = ColorMode.Auto) => ColorProvider.UseWindowsAccentColor(colorMode);

    /// <inheritdoc cref="ColorProvider.SetPalettes(Color, ColorMode)"/>
    public static void SetPalettes(Color color, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetPalettes(color, colorMode);

    /// <inheritdoc cref="ColorProvider.SetPalettes(Color, Color, Color, ColorMode)"/>
    public static void SetPalettes(Color primary, Color secondary, Color tertiary, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetPalettes(primary, secondary, tertiary, colorMode);

    /// <inheritdoc cref="ColorProvider.SetPalettes(string, ColorMode)"/>
    public static bool SetPalettes(string xamlPath, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetPalettes(xamlPath, colorMode);

    /// <inheritdoc cref="ColorProvider.SetPalettes(Dictionary{string, object}, ColorMode)"/>
    public static bool SetPalettes(Dictionary<string, object> collection, ColorMode colorMode = ColorMode.Auto) => ColorProvider.SetPalettes(collection, colorMode);

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