﻿using Peponi.Google.MaterialColorUtilities;
using Peponi.MaterialDesign3.WPF.ThemeProvider;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF;

/// <summary>
/// Enum for setting theme mode
/// </summary>
public enum ColorMode
{
    /// <summary>
    /// Use windows theme option
    /// </summary>
    Auto,

    /// <summary>
    /// Set light mode
    /// </summary>
    Light,

    /// <summary>
    /// Set dark mode
    /// </summary>
    Dark
}

/// <summary>
/// Provides material theme
/// </summary>
/// <remarks>
/// <see href="https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.MaterialDesign3/Peponi.MaterialDesign3.WPF"/>
/// </remarks>
public partial class MaterialTheme : ResourceDictionary
{
    private Color _pri = Color.FromRgb(0x00, 0xA3, 0xE3);

    [Description("Primary color of palette"), Category("Material color")]
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

    [Description("Secondary color of palette"), Category("Material color")]
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

    [Description("Tertiary color of palette"), Category("Material color")]
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

    /// <summary>
    /// <para>
    /// Set color mode for default color set
    /// </para>
    /// <para>
    /// 1. <see cref="ColorMode.Light"/><br/>
    /// 2. <see cref="ColorMode.Dark"/><br/>
    /// 3. <see cref="ColorMode.Auto"/>
    /// </para>
    /// </summary>
    [Description("Set color mode for default color set"), Category("Material color")]
    public ColorMode ColorMode
    {
        get => _colorProvider.ColorMode;
        set
        {
            _colorProvider.ColorMode = value;
        }
    }

    /// <summary>
    /// Use windows accent color option<br/>
    /// Supports Windows 10, 11
    /// </summary>
    [Description("Use windows accent color option\r\nSupports Windows 10, 11"), Category("Material color")]
    public bool UseWindowsAccentColor
    {
        get => _colorProvider.UseWindowsAccentColor;
        set
        {
            _colorProvider.UseWindowsAccentColor = value;
        }
    }

    private FontFamily? _fontFamily;

    [Description("Primary font family"), Category("Material font")]
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

    [Description("Secondary font family"), Category("Material font")]
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

    [Description("Tertiary font family"), Category("Material font")]
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

    /// <summary>
    /// Current color palettes
    /// </summary>
    public Dictionary<TonalPalettes, TonalPalette> ColorPalettes => _colorProvider.ColorPalettes;

#pragma warning disable CS0618
    private static MaterialTheme _current = new();
#pragma warning restore CS0618

    /// <summary>
    /// Current resource dictionary
    /// </summary>
    public static MaterialTheme Current => _current;

    private ColorProvider _colorProvider;
    private FontProvider _fontProvider;

    [Obsolete("Intended to internal use of library")]
    public MaterialTheme()
    {
        InitializeComponent();
        _current = this;

        _colorProvider = new(_current, Primary, Secondary, Tertiary);
        _fontProvider = new FontProvider(_current);
    }

    /// <inheritdoc cref="SetPalettes(Color, Color?, Color?)"/>
    public void SetPalettes(Color primary)
    {
        _pri = primary;
        _sec = null;
        _ter = null;
        _colorProvider.SetPalettes(primary, null, null);
    }

    /// <summary>
    /// Create tonal spot palette by given color<br/>
    /// Neutral, Neutral variant colors are decided by primary color
    /// </summary>
    /// <param name="primary"></param>
    /// <param name="secondary"></param>
    /// <param name="tertiary"></param>
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
    /// Sets color, font values by given dictionary<br/>
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
}