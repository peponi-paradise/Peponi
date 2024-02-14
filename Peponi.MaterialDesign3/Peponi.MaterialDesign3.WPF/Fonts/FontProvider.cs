using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF.Fonts;

public record FontOption(double FontSize, double LineHeight, FontWeight FontWeight);

public static class FontProvider
{
    private static ResourceDictionary _resource = new();
    private const string FontFamily = "FontFamily";

    /// <summary>
    /// Set font family by given name<br/>
    /// Font family should exists on resource dictionary
    /// </summary>
    /// <param name="fontFamily">Name of font family</param>
    /// <returns>Success or fail</returns>
    public static bool SetFontFamily(string fontFamily)
    {
        FontFamily family;
        try
        {
            family = new(fontFamily);
        }
        catch
        {
            return false;
        }

        _resource[fontFamily] = family;
        _resource[FontFamily] = family;
        return true;
    }

    /// <summary>
    /// Add new font to resource dictionary
    /// </summary>
    /// <param name="fontFamily">Name of font family</param>
    /// <param name="uri">Uri of font file</param>
    /// <returns>Success or fail</returns>
    public static bool SetFontFamily(string fontFamily, string uri)
    {
        FontFamily family;
        try
        {
            family = new(new Uri(uri), fontFamily);
        }
        catch
        {
            return false;
        }

        _resource[fontFamily] = family;
        _resource[FontFamily] = family;
        return true;
    }

    /// <summary>
    /// Set font option<br/>
    /// See readme for details
    /// </summary>
    /// <param name="key">Option key</param>
    /// <param name="option">Font option</param>
    public static void SetFontOption(string key, FontOption option)
    {
        _resource[$"{nameof(option.FontSize)}.{key}"] = option.FontSize;
        _resource[$"{nameof(option.LineHeight)}.{key}"] = option.LineHeight;
        _resource[$"{nameof(option.FontWeight)}.{key}"] = option.FontWeight;
    }

    /// <summary>
    /// Set font option<br/>
    /// See readme for details
    /// </summary>
    /// <param name="xamlPath"></param>
    /// <returns>Success or fail</returns>
    public static bool LoadXaml(string xamlPath)
    {
        try
        {
            var res = new ResourceDictionary() { Source = new Uri(xamlPath, UriKind.RelativeOrAbsolute) };

            foreach (var item in res.Keys) _resource[item] = res[item];
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Set font option<br/>
    /// See readme for details
    /// </summary>
    /// <param name="collection"></param>
    /// <returns>Success or fail</returns>
    public static void SetCollection(Dictionary<string, FontOption> collection)
    {
        foreach (var item in collection) SetFontOption(item.Key, item.Value);
    }

    internal static void InitializeInternal(ResourceDictionary resource)
    {
        _resource = resource;
        _resource[FontFamily] = _resource["RobotoFlex"];
    }
}