using Google.MaterialColorUtilities;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF.Colors;

/// <summary>
/// Enum for setting theme mode
/// </summary>
public enum ColorMode
{
    /// <summary>
    /// Set light mode
    /// </summary>
    Light,

    /// <summary>
    /// Set dark mode
    /// </summary>
    Dark,

    /// <summary>
    /// Use windows theme option
    /// </summary>
    Auto
}

public static class ColorProvider
{
    public static Dictionary<TonalPalettes, TonalPalette> Palettes;
    public static Indexer? ThemeColors;

    private static ResourceDictionary? _resource;

    private static bool _useWindowsAccentColor = false;
    private static ColorMode _colorMode = ColorMode.Auto;

    static ColorProvider()
    {
        Palettes = new Dictionary<TonalPalettes, TonalPalette>
        {
            { TonalPalettes.Primary, new() },
            { TonalPalettes.Secondary, new() },
            { TonalPalettes.Tertiary, new() },
            { TonalPalettes.Neutral, new() },
            { TonalPalettes.NeutralVariant, new() },
            { TonalPalettes.Error, new(25, 84) }
        };

        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
    }

    private static void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        switch (e.Category)
        {
            case UserPreferenceCategory.General:
                if (_useWindowsAccentColor) CreatePalettes(GetAccentColor(), null, null);
                SetResources(_colorMode);
                break;
        }
    }

    /// <summary>
    /// Use windows accent color option<br/>
    /// Supports Windows 10, 11
    /// </summary>
    /// <param name="colorMode">
    /// 1. <see cref="ColorMode.Light"/><br/>
    /// 2. <see cref="ColorMode.Dark"/><br/>
    /// 3. <see cref="ColorMode.Auto"/>
    /// </param>
    public static void UseWindowsAccentColor(ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = true;

        CreatePalettes(GetAccentColor(), null, null);

        SetResources(colorMode);
    }

    /// <summary>
    /// Create tonal spot palette by given color
    /// </summary>
    /// <param name="color">Primary color</param>
    /// <param name="colorMode">
    /// 1. <see cref="ColorMode.Light"/><br/>
    /// 2. <see cref="ColorMode.Dark"/><br/>
    /// 3. <see cref="ColorMode.Auto"/>
    /// </param>
    public static void SetPalettes(Color color, ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = false;

        CreatePalettes(color, null, null);

        SetResources(colorMode);
    }

    /// <summary>
    /// Create tonal spot palette by given color<br/>
    /// Neutral, Neutral variant colors are decided by primary color
    /// </summary>
    /// <param name="primary"></param>
    /// <param name="secondary"></param>
    /// <param name="tertiary"></param>
    /// <param name="colorMode">
    /// 1. <see cref="ColorMode.Light"/><br/>
    /// 2. <see cref="ColorMode.Dark"/><br/>
    /// 3. <see cref="ColorMode.Auto"/>
    /// </param>
    public static void SetPalettes(Color primary, Color? secondary, Color? tertiary, ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = false;

        CreatePalettes(primary, secondary, tertiary);

        SetResources(colorMode);
    }

    /// <summary>
    /// Set color, brush values by given xaml<br/>
    /// See readme for details
    /// </summary>
    /// <param name="xamlPath"></param>
    /// <param name="colorMode">
    /// 1. <see cref="ColorMode.Light"/><br/>
    /// 2. <see cref="ColorMode.Dark"/><br/>
    /// 3. <see cref="ColorMode.Auto"/>
    /// </param>
    /// <returns>Success or fail</returns>
    public static bool SetPalettes(string xamlPath, ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = false;

        try
        {
            var res = new ResourceDictionary() { Source = new Uri(xamlPath, UriKind.RelativeOrAbsolute) };
            foreach (var item in res.Keys) _resource![item] = res[item];
        }
        catch
        {
            return false;
        }

        SetResources(colorMode);
        return true;
    }

    /// <summary>
    /// Set color, brush values by given dictionary<br/>
    /// See readme for details
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="colorMode">
    /// 1. <see cref="ColorMode.Light"/><br/>
    /// 2. <see cref="ColorMode.Dark"/><br/>
    /// 3. <see cref="ColorMode.Auto"/>
    /// </param>
    /// <returns>Success or fail</returns>
    public static bool SetPalettes(Dictionary<string, object> collection, ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = false;

        if (collection is null) return false;
        else
        {
            foreach (var item in collection) _resource![item.Key] = item.Value;
        }

        SetResources(colorMode);
        return true;
    }

    /// <summary>
    /// Set color mode for default color set
    /// </summary>
    /// <param name="colorMode">
    /// 1. <see cref="ColorMode.Light"/><br/>
    /// 2. <see cref="ColorMode.Dark"/><br/>
    /// 3. <see cref="ColorMode.Auto"/>
    /// </param>
    public static void SetColorMode(ColorMode colorMode)
    {
        if (_resource is not null)
        {
            SetResources(colorMode);
        }
    }

    internal static void InitializeInternal(ResourceDictionary resource, Color primary, Color? secondary, Color? tertiary, ColorMode colorMode)
    {
        _resource = resource;
        ThemeColors = new(resource);

        SetPalettes(primary, secondary, tertiary, colorMode);
    }

    private static void CreatePalettes(Color primary, Color? secondary, Color? tertiary)
    {
        Palettes[TonalPalettes.Primary] = new TonalPalette(primary.ToDrawing());
        var hue = Palettes[TonalPalettes.Primary].Hue;
        Palettes[TonalPalettes.Secondary] = secondary == null ? new TonalPalette(hue, 16) : new TonalPalette(((Color)secondary).ToDrawing());
        Palettes[TonalPalettes.Tertiary] = tertiary == null ? new TonalPalette(hue + 60, 24) : new TonalPalette(((Color)tertiary).ToDrawing());
        Palettes[TonalPalettes.Neutral] = new TonalPalette(hue, 4);
        Palettes[TonalPalettes.NeutralVariant] = new TonalPalette(hue, 8);
    }

    private static void SetResources(ColorMode colorMode)
    {
        _colorMode = colorMode;

        switch (_colorMode)
        {
            case ColorMode.Light:
                SetLight();
                break;

            case ColorMode.Dark:
                SetDark();
                break;

            case ColorMode.Auto:
                if (IsSystemLight()) SetLight();
                else SetDark();
                break;
        }
    }

    private static bool IsSystemLight()
    {
        RegistryKey registry = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize")!;
        return (int)registry.GetValue("SystemUsesLightTheme")! == 1;
    }

    [DllImport("uxtheme.dll", EntryPoint = "#95")]
    private static extern uint GetImmersiveColorFromColorSetEx(uint dwImmersiveColorSet, uint dwImmersiveColorType,
                                                                    bool bIgnoreHighContrast, uint dwHighContrastCacheMode);

    [DllImport("uxtheme.dll", EntryPoint = "#96")]
    private static extern uint GetImmersiveColorTypeFromName(IntPtr pName);

    [DllImport("uxtheme.dll", EntryPoint = "#98")]
    private static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

    private static Color GetAccentColor()
    {
        var userColorSet = GetImmersiveUserColorSetPreference(false, false);
        var colorType = GetImmersiveColorTypeFromName(Marshal.StringToHGlobalUni("ImmersiveStartSelectionBackground"));
        var colorSetEx = GetImmersiveColorFromColorSetEx((uint)userColorSet, colorType, false, 0);
        byte redColor = (byte)((0x000000FF & colorSetEx) >> 0);
        byte greenColor = (byte)((0x0000FF00 & colorSetEx) >> 8);
        byte blueColor = (byte)((0x00FF0000 & colorSetEx) >> 16);
        byte alphaColor = (byte)((0xFF000000 & colorSetEx) >> 24);
        return Color.FromArgb(alphaColor, redColor, greenColor, blueColor);
    }

    private static void SetLight()
    {
        _resource![MaterialColor.Primary] = Palettes[TonalPalettes.Primary][40].ToMedia();
        _resource![MaterialColor.OnPrimary] = Palettes[TonalPalettes.Primary][100].ToMedia();
        _resource![MaterialColor.PrimaryContainer] = Palettes[TonalPalettes.Primary][90].ToMedia();
        _resource![MaterialColor.OnPrimaryContainer] = Palettes[TonalPalettes.Primary][10].ToMedia();
        _resource![MaterialColor.Secondary] = Palettes[TonalPalettes.Secondary][40].ToMedia();
        _resource![MaterialColor.OnSecondary] = Palettes[TonalPalettes.Secondary][100].ToMedia();
        _resource![MaterialColor.SecondaryContainer] = Palettes[TonalPalettes.Secondary][90].ToMedia();
        _resource![MaterialColor.OnSecondaryContainer] = Palettes[TonalPalettes.Secondary][10].ToMedia();
        _resource![MaterialColor.Tertiary] = Palettes[TonalPalettes.Tertiary][40].ToMedia();
        _resource![MaterialColor.OnTertiary] = Palettes[TonalPalettes.Tertiary][100].ToMedia();
        _resource![MaterialColor.TertiaryContainer] = Palettes[TonalPalettes.Tertiary][90].ToMedia();
        _resource![MaterialColor.OnTertiaryContainer] = Palettes[TonalPalettes.Tertiary][10].ToMedia();
        _resource![MaterialColor.Error] = Palettes[TonalPalettes.Error][40].ToMedia();
        _resource![MaterialColor.OnError] = Palettes[TonalPalettes.Error][100].ToMedia();
        _resource![MaterialColor.ErrorContainer] = Palettes[TonalPalettes.Error][90].ToMedia();
        _resource![MaterialColor.OnErrorContainer] = Palettes[TonalPalettes.Error][10].ToMedia();
        _resource![MaterialColor.PrimaryFixed] = Palettes[TonalPalettes.Primary][90].ToMedia();
        _resource![MaterialColor.PrimaryFixedDim] = Palettes[TonalPalettes.Primary][80].ToMedia();
        _resource![MaterialColor.OnPrimaryFixed] = Palettes[TonalPalettes.Primary][10].ToMedia();
        _resource![MaterialColor.OnPrimaryFixedVariant] = Palettes[TonalPalettes.Primary][30].ToMedia();
        _resource![MaterialColor.SecondaryFixed] = Palettes[TonalPalettes.Secondary][90].ToMedia();
        _resource![MaterialColor.SecondaryFixedDim] = Palettes[TonalPalettes.Secondary][80].ToMedia();
        _resource![MaterialColor.OnSecondaryFixed] = Palettes[TonalPalettes.Secondary][10].ToMedia();
        _resource![MaterialColor.OnSecondaryFixedVariant] = Palettes[TonalPalettes.Secondary][30].ToMedia();
        _resource![MaterialColor.TertiaryFixed] = Palettes[TonalPalettes.Tertiary][90].ToMedia();
        _resource![MaterialColor.TertiaryFixedDim] = Palettes[TonalPalettes.Tertiary][80].ToMedia();
        _resource![MaterialColor.OnTertiaryFixed] = Palettes[TonalPalettes.Tertiary][10].ToMedia();
        _resource![MaterialColor.OnTertiaryFixedVariant] = Palettes[TonalPalettes.Tertiary][30].ToMedia();
        _resource![MaterialColor.SurfaceDim] = Palettes[TonalPalettes.Neutral][87].ToMedia();
        _resource![MaterialColor.Surface] = Palettes[TonalPalettes.Neutral][98].ToMedia();
        _resource![MaterialColor.SurfaceBright] = Palettes[TonalPalettes.Neutral][98].ToMedia();
        _resource![MaterialColor.SurfaceContainerLowest] = Palettes[TonalPalettes.Neutral][100].ToMedia();
        _resource![MaterialColor.SurfaceContainerLow] = Palettes[TonalPalettes.Neutral][96].ToMedia();
        _resource![MaterialColor.SurfaceContainer] = Palettes[TonalPalettes.Neutral][94].ToMedia();
        _resource![MaterialColor.SurfaceContainerHigh] = Palettes[TonalPalettes.Neutral][92].ToMedia();
        _resource![MaterialColor.SurfaceContainerHighest] = Palettes[TonalPalettes.Neutral][90].ToMedia();
        _resource![MaterialColor.OnSurface] = Palettes[TonalPalettes.Neutral][10].ToMedia();
        _resource![MaterialColor.OnSurfaceVariant] = Palettes[TonalPalettes.NeutralVariant][30].ToMedia();
        _resource![MaterialColor.Outline] = Palettes[TonalPalettes.NeutralVariant][50].ToMedia();
        _resource![MaterialColor.OutlineVariant] = Palettes[TonalPalettes.NeutralVariant][80].ToMedia();
        _resource![MaterialColor.InverseSurface] = Palettes[TonalPalettes.Neutral][20].ToMedia();
        _resource![MaterialColor.InverseOnSurface] = Palettes[TonalPalettes.Neutral][95].ToMedia();
        _resource![MaterialColor.InversePrimary] = Palettes[TonalPalettes.Primary][80].ToMedia();
        _resource![MaterialColor.Scrim] = Palettes[TonalPalettes.Neutral][0].ToMedia();
        _resource![MaterialColor.Shadow] = Palettes[TonalPalettes.Neutral][0].ToMedia();

        SetSolidBrush();
    }

    private static void SetDark()
    {
        _resource![MaterialColor.Primary] = Palettes[TonalPalettes.Primary][80].ToMedia();
        _resource![MaterialColor.OnPrimary] = Palettes[TonalPalettes.Primary][20].ToMedia();
        _resource![MaterialColor.PrimaryContainer] = Palettes[TonalPalettes.Primary][30].ToMedia();
        _resource![MaterialColor.OnPrimaryContainer] = Palettes[TonalPalettes.Primary][90].ToMedia();
        _resource![MaterialColor.Secondary] = Palettes[TonalPalettes.Secondary][80].ToMedia();
        _resource![MaterialColor.OnSecondary] = Palettes[TonalPalettes.Secondary][20].ToMedia();
        _resource![MaterialColor.SecondaryContainer] = Palettes[TonalPalettes.Secondary][30].ToMedia();
        _resource![MaterialColor.OnSecondaryContainer] = Palettes[TonalPalettes.Secondary][90].ToMedia();
        _resource![MaterialColor.Tertiary] = Palettes[TonalPalettes.Tertiary][80].ToMedia();
        _resource![MaterialColor.OnTertiary] = Palettes[TonalPalettes.Tertiary][20].ToMedia();
        _resource![MaterialColor.TertiaryContainer] = Palettes[TonalPalettes.Tertiary][30].ToMedia();
        _resource![MaterialColor.OnTertiaryContainer] = Palettes[TonalPalettes.Tertiary][90].ToMedia();
        _resource![MaterialColor.Error] = Palettes[TonalPalettes.Error][80].ToMedia();
        _resource![MaterialColor.OnError] = Palettes[TonalPalettes.Error][20].ToMedia();
        _resource![MaterialColor.ErrorContainer] = Palettes[TonalPalettes.Error][30].ToMedia();
        _resource![MaterialColor.OnErrorContainer] = Palettes[TonalPalettes.Error][90].ToMedia();
        _resource![MaterialColor.PrimaryFixed] = Palettes[TonalPalettes.Primary][90].ToMedia();
        _resource![MaterialColor.PrimaryFixedDim] = Palettes[TonalPalettes.Primary][80].ToMedia();
        _resource![MaterialColor.OnPrimaryFixed] = Palettes[TonalPalettes.Primary][10].ToMedia();
        _resource![MaterialColor.OnPrimaryFixedVariant] = Palettes[TonalPalettes.Primary][30].ToMedia();
        _resource![MaterialColor.SecondaryFixed] = Palettes[TonalPalettes.Secondary][90].ToMedia();
        _resource![MaterialColor.SecondaryFixedDim] = Palettes[TonalPalettes.Secondary][80].ToMedia();
        _resource![MaterialColor.OnSecondaryFixed] = Palettes[TonalPalettes.Secondary][10].ToMedia();
        _resource![MaterialColor.OnSecondaryFixedVariant] = Palettes[TonalPalettes.Secondary][30].ToMedia();
        _resource![MaterialColor.TertiaryFixed] = Palettes[TonalPalettes.Tertiary][90].ToMedia();
        _resource![MaterialColor.TertiaryFixedDim] = Palettes[TonalPalettes.Tertiary][80].ToMedia();
        _resource![MaterialColor.OnTertiaryFixed] = Palettes[TonalPalettes.Tertiary][10].ToMedia();
        _resource![MaterialColor.OnTertiaryFixedVariant] = Palettes[TonalPalettes.Tertiary][30].ToMedia();
        _resource![MaterialColor.SurfaceDim] = Palettes[TonalPalettes.Neutral][6].ToMedia();
        _resource![MaterialColor.Surface] = Palettes[TonalPalettes.Neutral][6].ToMedia();
        _resource![MaterialColor.SurfaceBright] = Palettes[TonalPalettes.Neutral][24].ToMedia();
        _resource![MaterialColor.SurfaceContainerLowest] = Palettes[TonalPalettes.Neutral][4].ToMedia();
        _resource![MaterialColor.SurfaceContainerLow] = Palettes[TonalPalettes.Neutral][10].ToMedia();
        _resource![MaterialColor.SurfaceContainer] = Palettes[TonalPalettes.Neutral][12].ToMedia();
        _resource![MaterialColor.SurfaceContainerHigh] = Palettes[TonalPalettes.Neutral][17].ToMedia();
        _resource![MaterialColor.SurfaceContainerHighest] = Palettes[TonalPalettes.Neutral][22].ToMedia();
        _resource![MaterialColor.OnSurface] = Palettes[TonalPalettes.Neutral][90].ToMedia();
        _resource![MaterialColor.OnSurfaceVariant] = Palettes[TonalPalettes.NeutralVariant][80].ToMedia();
        _resource![MaterialColor.Outline] = Palettes[TonalPalettes.NeutralVariant][60].ToMedia();
        _resource![MaterialColor.OutlineVariant] = Palettes[TonalPalettes.NeutralVariant][30].ToMedia();
        _resource![MaterialColor.InverseSurface] = Palettes[TonalPalettes.Neutral][90].ToMedia();
        _resource![MaterialColor.InverseOnSurface] = Palettes[TonalPalettes.Neutral][20].ToMedia();
        _resource![MaterialColor.InversePrimary] = Palettes[TonalPalettes.Primary][40].ToMedia();
        _resource![MaterialColor.Scrim] = Palettes[TonalPalettes.Neutral][0].ToMedia();
        _resource![MaterialColor.Shadow] = Palettes[TonalPalettes.Neutral][0].ToMedia();

        SetSolidBrush();
    }

    private static void SetSolidBrush()
    {
        _resource![MaterialBrush.Primary] = new SolidColorBrush() { Color = _resource![MaterialColor.Primary].ToMedia() };
        _resource![MaterialBrush.OnPrimary] = new SolidColorBrush() { Color = _resource![MaterialColor.OnPrimary].ToMedia() };
        _resource![MaterialBrush.PrimaryContainer] = new SolidColorBrush() { Color = _resource![MaterialColor.PrimaryContainer].ToMedia() };
        _resource![MaterialBrush.OnPrimaryContainer] = new SolidColorBrush() { Color = _resource![MaterialColor.OnPrimaryContainer].ToMedia() };
        _resource![MaterialBrush.Secondary] = new SolidColorBrush() { Color = _resource![MaterialColor.Secondary].ToMedia() };
        _resource![MaterialBrush.OnSecondary] = new SolidColorBrush() { Color = _resource![MaterialColor.OnSecondary].ToMedia() };
        _resource![MaterialBrush.SecondaryContainer] = new SolidColorBrush() { Color = _resource![MaterialColor.SecondaryContainer].ToMedia() };
        _resource![MaterialBrush.OnSecondaryContainer] = new SolidColorBrush() { Color = _resource![MaterialColor.OnSecondaryContainer].ToMedia() };
        _resource![MaterialBrush.Tertiary] = new SolidColorBrush() { Color = _resource![MaterialColor.Tertiary].ToMedia() };
        _resource![MaterialBrush.OnTertiary] = new SolidColorBrush() { Color = _resource![MaterialColor.OnTertiary].ToMedia() };
        _resource![MaterialBrush.TertiaryContainer] = new SolidColorBrush() { Color = _resource![MaterialColor.TertiaryContainer].ToMedia() };
        _resource![MaterialBrush.OnTertiaryContainer] = new SolidColorBrush() { Color = _resource![MaterialColor.OnTertiaryContainer].ToMedia() };
        _resource![MaterialBrush.Error] = new SolidColorBrush() { Color = _resource![MaterialColor.Error].ToMedia() };
        _resource![MaterialBrush.OnError] = new SolidColorBrush() { Color = _resource![MaterialColor.OnError].ToMedia() };
        _resource![MaterialBrush.ErrorContainer] = new SolidColorBrush() { Color = _resource![MaterialColor.ErrorContainer].ToMedia() };
        _resource![MaterialBrush.OnErrorContainer] = new SolidColorBrush() { Color = _resource![MaterialColor.OnErrorContainer].ToMedia() };
        _resource![MaterialBrush.PrimaryFixed] = new SolidColorBrush() { Color = _resource![MaterialColor.PrimaryFixed].ToMedia() };
        _resource![MaterialBrush.PrimaryFixedDim] = new SolidColorBrush() { Color = _resource![MaterialColor.PrimaryFixedDim].ToMedia() };
        _resource![MaterialBrush.OnPrimaryFixed] = new SolidColorBrush() { Color = _resource![MaterialColor.OnPrimaryFixed].ToMedia() };
        _resource![MaterialBrush.OnPrimaryFixedVariant] = new SolidColorBrush() { Color = _resource![MaterialColor.OnPrimaryFixedVariant].ToMedia() };
        _resource![MaterialBrush.SecondaryFixed] = new SolidColorBrush() { Color = _resource![MaterialColor.SecondaryFixed].ToMedia() };
        _resource![MaterialBrush.SecondaryFixedDim] = new SolidColorBrush() { Color = _resource![MaterialColor.SecondaryFixedDim].ToMedia() };
        _resource![MaterialBrush.OnSecondaryFixed] = new SolidColorBrush() { Color = _resource![MaterialColor.OnSecondaryFixed].ToMedia() };
        _resource![MaterialBrush.OnSecondaryFixedVariant] = new SolidColorBrush() { Color = _resource![MaterialColor.OnSecondaryFixedVariant].ToMedia() };
        _resource![MaterialBrush.TertiaryFixed] = new SolidColorBrush() { Color = _resource![MaterialColor.TertiaryFixed].ToMedia() };
        _resource![MaterialBrush.TertiaryFixedDim] = new SolidColorBrush() { Color = _resource![MaterialColor.TertiaryFixedDim].ToMedia() };
        _resource![MaterialBrush.OnTertiaryFixed] = new SolidColorBrush() { Color = _resource![MaterialColor.OnTertiaryFixed].ToMedia() };
        _resource![MaterialBrush.OnTertiaryFixedVariant] = new SolidColorBrush() { Color = _resource![MaterialColor.OnTertiaryFixedVariant].ToMedia() };
        _resource![MaterialBrush.SurfaceDim] = new SolidColorBrush() { Color = _resource![MaterialColor.SurfaceDim].ToMedia() };
        _resource![MaterialBrush.Surface] = new SolidColorBrush() { Color = _resource![MaterialColor.Surface].ToMedia() };
        _resource![MaterialBrush.SurfaceBright] = new SolidColorBrush() { Color = _resource![MaterialColor.SurfaceBright].ToMedia() };
        _resource![MaterialBrush.SurfaceContainerLowest] = new SolidColorBrush() { Color = _resource![MaterialColor.SurfaceContainerLowest].ToMedia() };
        _resource![MaterialBrush.SurfaceContainerLow] = new SolidColorBrush() { Color = _resource![MaterialColor.SurfaceContainerLow].ToMedia() };
        _resource![MaterialBrush.SurfaceContainer] = new SolidColorBrush() { Color = _resource![MaterialColor.SurfaceContainer].ToMedia() };
        _resource![MaterialBrush.SurfaceContainerHigh] = new SolidColorBrush() { Color = _resource![MaterialColor.SurfaceContainerHigh].ToMedia() };
        _resource![MaterialBrush.SurfaceContainerHighest] = new SolidColorBrush() { Color = _resource![MaterialColor.SurfaceContainerHighest].ToMedia() };
        _resource![MaterialBrush.OnSurface] = new SolidColorBrush() { Color = _resource![MaterialColor.OnSurface].ToMedia() };
        _resource![MaterialBrush.OnSurfaceVariant] = new SolidColorBrush() { Color = _resource![MaterialColor.OnSurfaceVariant].ToMedia() };
        _resource![MaterialBrush.Outline] = new SolidColorBrush() { Color = _resource![MaterialColor.Outline].ToMedia() };
        _resource![MaterialBrush.OutlineVariant] = new SolidColorBrush() { Color = _resource![MaterialColor.OutlineVariant].ToMedia() };
        _resource![MaterialBrush.InverseSurface] = new SolidColorBrush() { Color = _resource![MaterialColor.InverseSurface].ToMedia() };
        _resource![MaterialBrush.InverseOnSurface] = new SolidColorBrush() { Color = _resource![MaterialColor.InverseOnSurface].ToMedia() };
        _resource![MaterialBrush.InversePrimary] = new SolidColorBrush() { Color = _resource![MaterialColor.InversePrimary].ToMedia() };
        _resource![MaterialBrush.Scrim] = new SolidColorBrush() { Color = _resource![MaterialColor.Scrim].ToMedia() };
        _resource![MaterialBrush.Shadow] = new SolidColorBrush() { Color = _resource![MaterialColor.Shadow].ToMedia() };
    }

    private static Color ToMedia(this System.Drawing.Color color) => Color.FromRgb(color.R, color.G, color.B);

    private static Color ToMedia(this object color)
    {
        var rgb = (Color)color;
        return Color.FromRgb(rgb.R, rgb.G, rgb.B);
    }

    private static System.Drawing.Color ToDrawing(this Color color) => System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
}