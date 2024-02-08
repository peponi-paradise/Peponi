using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF.Fonts;

public record FontOption(double FontSize, double LineHeight, FontWeight FontWeight);

public static class FontProvider
{
    private static ResourceDictionary? _resource;
    private const string FontFamily = "FontFamily";

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

    public static bool SetFontFamily(string fontFamily)
    {
        if (!_resource!.Contains(fontFamily)) return false;

        _resource[FontFamily] = _resource[fontFamily];
        return true;
    }

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

    public static bool SetFontOption(string xamlPath)
    {
        return false;
    }

    public static bool SetFontOption(Dictionary<string, FontOption> collection)
    {
        return false;
    }

    internal static void InitializeInternal(ResourceDictionary resource)
    {
        _resource = resource;
        _resource[FontFamily] = _resource["RobotoFlex"];
    }
}