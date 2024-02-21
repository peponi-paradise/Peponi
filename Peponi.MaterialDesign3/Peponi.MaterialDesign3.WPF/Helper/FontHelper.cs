using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF;

public static class FontHelper
{
    /// <summary>
    /// Gets font family by given name<br/>
    /// If name is registered in the resource dictionary, the corresponding value will be returned<br/>
    /// If not, new instance will be returned
    /// </summary>
    /// <param name="name"></param>
    /// <returns>null if there is not in resource dictionary or failed to create instance</returns>
    public static FontFamily? GetFontFamily(string name)
    {
        try
        {
            if (MaterialTheme.Current.Contains(name)) return (FontFamily)MaterialTheme.Current[name];
            else return new(name);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Gets font family by given name and uri<br/>
    /// Uri requires absolute path
    /// </summary>
    /// <param name="name"></param>
    /// <param name="uri">Absolute path</param>
    /// <returns>null if failed to create instance</returns>
    public static FontFamily? GetFontFamily(string name, string uri)
    {
        try
        {
            return new(new Uri(uri, UriKind.Absolute), name);
        }
        catch
        {
            return null;
        }
    }
}