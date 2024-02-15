using Google.MaterialColorUtilities;
using Peponi.MaterialDesign3.WPF.Colors;
using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF;

public partial class MaterialTheme : ResourceDictionary
{
    private Color _pri = Color.FromRgb(0x75, 0x75, 0x75);

    public Color Primary
    {
        get => _pri;
        set
        {
            if (_pri != value)
            {
                _pri = value;
                SetPalettes(Primary, Secondary, Tertiary);
            }
        }
    }

    private Color? _sec = null;

    public Color? Secondary
    {
        get => _sec;
        set
        {
            if (_sec != value)
            {
                _sec = value;
                SetPalettes(Primary, Secondary, Tertiary);
            }
        }
    }

    private Color? _ter = null;

    public Color? Tertiary
    {
        get => _ter;
        set
        {
            if (_ter != value)
            {
                _ter = value;
                SetPalettes(Primary, Secondary, Tertiary);
            }
        }
    }

    /// <inheritdoc cref="ColorProvider.ColorMode"/>
    public ColorMode ColorMode
    {
        get => _colorProvider.ColorMode;
        set
        {
            _colorProvider.ColorMode = value;
        }
    }

    /// <inheritdoc cref="ColorProvider.UseWindowsAccentColor"/>
    public bool UseWindowsAccentColor
    {
        get => _colorProvider.UseWindowsAccentColor;
        set
        {
            _colorProvider.UseWindowsAccentColor = value;
        }
    }

    private FontFamily? _fontFamily;

    public FontFamily? FontFamily
    {
        get => _fontFamily;
        set
        {
            if (_fontFamily != value)
            {
                _fontFamily = value;
                _current[MaterialFont.FontFamily] = value;
            }
        }
    }

    private FontFamily? _secondaryFontFamily;

    public FontFamily? SecondaryFontFamily
    {
        get => _secondaryFontFamily;
        set
        {
            if (_secondaryFontFamily != value)
            {
                _secondaryFontFamily = value;
                _current[MaterialFont.SecondaryFontFamily] = value;
            }
        }
    }

    private FontFamily? _tertiaryFontFamily;

    public FontFamily? TertiaryFontFamily
    {
        get => _tertiaryFontFamily;
        set
        {
            if (_tertiaryFontFamily != value)
            {
                _tertiaryFontFamily = value;
                _current[MaterialFont.TertiaryFontFamily] = value;
            }
        }
    }

    public Dictionary<TonalPalettes, TonalPalette> ColorPalettes => _colorProvider.ColorPalettes;

    private static MaterialTheme _current = new();
    public static MaterialTheme Current => _current;

    private ColorProvider _colorProvider;

    public MaterialTheme()
    {
        InitializeComponent();
        _current = this;

        _colorProvider = new(_current, Primary, Secondary, Tertiary);

        SetDefaultFonts();
    }

    /// <inheritdoc cref="ColorProvider.SetPalettes(Color, Color?, Color?)"/>
    public void SetPalettes(Color primary)
    {
        _pri = primary;
        _colorProvider.SetPalettes(primary, null, null);
    }

    /// <inheritdoc cref="ColorProvider.SetPalettes(Color, Color?, Color?)"/>
    public void SetPalettes(Color primary, Color? secondary, Color? tertiary)
    {
        _pri = primary;
        _sec = secondary;
        _ter = tertiary;
        _colorProvider.SetPalettes(primary, secondary, tertiary);
    }

    /// <summary>
    /// Sets color, font values by given xaml<br/>
    /// See readme for details
    /// </summary>
    /// <param name="xamlPath"></param>
    /// <returns>Success or fail</returns>
    public bool LoadXaml(string xamlPath)
    {
        _colorProvider.UseWindowsAccentColor = false;

        try
        {
            var res = new ResourceDictionary() { Source = new Uri(xamlPath, UriKind.RelativeOrAbsolute) };
            foreach (var item in res.Keys) _current[item] = res[item];
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Sets color, font values by given xaml<br/>
    /// See readme for details
    /// </summary>
    /// <param name="collection"></param>
    /// <returns>Success or fail</returns>
    public bool SetCollection(Dictionary<string, object> collection)
    {
        _colorProvider.UseWindowsAccentColor = false;

        if (collection is null) return false;
        else
        {
            foreach (var item in collection) _current[item.Key] = item.Value;
        }

        return true;
    }

    private void SetDefaultFonts()
    {
        _current[MaterialFont.FontFamily] = this[MaterialFont.DefaultFontFamily.RobotoFlex];
        _current[MaterialFont.SecondaryFontFamily] = this[MaterialFont.DefaultFontFamily.RobotoSerif];
        _current[MaterialFont.TertiaryFontFamily] = this[MaterialFont.DefaultFontFamily.Pretendard];
    }
}