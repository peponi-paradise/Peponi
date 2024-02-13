using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF.Fonts;

public record FontOption(double FontSize, double LineHeight, FontWeight FontWeight);

public static class FontProvider
{
    private static ResourceDictionary? _resource;
    private const string FontFamily = "FontFamily";

    static FontProvider()
    {
        InitializeInternal(new ResourceDictionary());
    }

    /// <summary>
    /// Add new font to resource dictionary
    /// </summary>
    /// <param name="fontFamily">Name of font family</param>
    /// <returns>Success or fail</returns>
    public static bool AddFontFamily(string fontFamily)
    {
        try
        {
            FontFamily family = new(fontFamily);
            _resource![fontFamily] = family;
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Add new font to resource dictionary
    /// </summary>
    /// <param name="fontFamily">Name of font family</param>
    /// <param name="uri">Uri of font file</param>
    /// <returns>Success or fail</returns>
    public static bool AddFontFamily(string fontFamily, string uri)
    {
        try
        {
            FontFamily family = new(new Uri(uri), fontFamily);
            _resource![fontFamily] = family;
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Set font family by given name<br/>
    /// Font family should exists on resource dictionary
    /// </summary>
    /// <param name="fontFamily">Name of font family</param>
    /// <returns>Success or fail</returns>
    public static bool SetFontFamily(string fontFamily)
    {
        if (!_resource!.Contains(fontFamily)) return false;

        _resource[FontFamily] = _resource[fontFamily];
        return true;
    }

    /// <summary>
    /// Set font option<br/>
    /// See readme for details
    /// </summary>
    /// <param name="key">Option key</param>
    /// <param name="option">Font option</param>
    /// <returns>Success or fail</returns>
    public static bool SetFontOption(string key, FontOption option)
    {
        if (!_resource!.Contains($"{nameof(option.FontSize)}.{key}")) return false;
        if (!_resource!.Contains($"{nameof(option.LineHeight)}.{key}")) return false;
        if (!_resource!.Contains($"{nameof(option.FontWeight)}.{key}")) return false;

        _resource[$"{nameof(option.FontSize)}.{key}"] = option.FontSize;
        _resource[$"{nameof(option.LineHeight)}.{key}"] = option.LineHeight;
        _resource[$"{nameof(option.FontWeight)}.{key}"] = option.FontWeight;
        return true;
    }

    /// <summary>
    /// Set font option<br/>
    /// See readme for details
    /// </summary>
    /// <param name="xamlPath"></param>
    /// <returns>Success or fail</returns>
    public static bool SetFontOption(string xamlPath)
    {
        try
        {
            var res = new ResourceDictionary() { Source = new Uri(xamlPath, UriKind.RelativeOrAbsolute) };

            foreach (var item in res.Keys) _resource![item] = res[item];
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
    public static bool SetFontOption(Dictionary<string, FontOption> collection)
    {
        foreach (var item in collection)
        {
            if (!SetFontOption(item.Key, item.Value)) return false;
        }
        return true;
    }

    internal static void InitializeInternal(ResourceDictionary resource)
    {
        _resource = resource;
        _resource[FontFamily] = _resource["RobotoFlex"];
    }
}