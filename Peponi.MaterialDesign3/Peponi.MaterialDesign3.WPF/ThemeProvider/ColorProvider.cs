using Peponi.Google.MaterialColorUtilities;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF.ThemeProvider;

internal class ColorProvider
{
    internal Dictionary<TonalPalettes, TonalPalette> ColorPalettes { get; private set; }

    /// <summary>
    /// Use windows accent color option<br/>
    /// Supports Windows 10, 11
    /// </summary>
    internal bool UseWindowsAccentColor
    {
        get => _useWindowsAccentColor;
        set
        {
            _useWindowsAccentColor = value;
            if (_useWindowsAccentColor)
            {
                CreatePalettes(GetAccentColor(), null, null);
                SetResources();
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
    internal ColorMode ColorMode
    {
        get => _colorMode;
        set
        {
            if (_colorMode != value)
            {
                _colorMode = value;
                SetResources();
            }
        }
    }

    private ResourceDictionary _resource;
    private bool _useWindowsAccentColor = false;
    private ColorMode _colorMode = ColorMode.Auto;

    internal ColorProvider(ResourceDictionary resource, Color primary, Color? secondary, Color? tertiary)
    {
        ColorPalettes = new Dictionary<TonalPalettes, TonalPalette>
        {
            { TonalPalettes.Primary, new() },
            { TonalPalettes.Secondary, new() },
            { TonalPalettes.Tertiary, new() },
            { TonalPalettes.Neutral, new() },
            { TonalPalettes.NeutralVariant, new() },
            { TonalPalettes.Error, new(25, 84) }
        };

        _resource = resource;

        SetPalettes(primary, secondary, tertiary);

        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
    }

    private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        switch (e.Category)
        {
            case UserPreferenceCategory.General:
                if (_useWindowsAccentColor) CreatePalettes(GetAccentColor(), null, null);
                SetResources();
                break;
        }
    }

    /// <summary>
    /// Create tonal spot palette by given color<br/>
    /// Neutral, Neutral variant colors are decided by primary color
    /// </summary>
    /// <param name="primary"></param>
    /// <param name="secondary"></param>
    /// <param name="tertiary"></param>
    internal void SetPalettes(Color primary, Color? secondary, Color? tertiary)
    {
        _useWindowsAccentColor = false;

        CreatePalettes(primary, secondary, tertiary);

        SetResources();
    }

    private void CreatePalettes(Color primary, Color? secondary, Color? tertiary)
    {
        ColorPalettes[TonalPalettes.Primary] = new TonalPalette(primary.ToDrawing());
        var hue = ColorPalettes[TonalPalettes.Primary].Hue;
        ColorPalettes[TonalPalettes.Secondary] = secondary == null ? new TonalPalette(hue, 16) : new TonalPalette(((Color)secondary).ToDrawing());
        ColorPalettes[TonalPalettes.Tertiary] = tertiary == null ? new TonalPalette(hue + 60, 24) : new TonalPalette(((Color)tertiary).ToDrawing());
        ColorPalettes[TonalPalettes.Neutral] = new TonalPalette(hue, 4);
        ColorPalettes[TonalPalettes.NeutralVariant] = new TonalPalette(hue, 8);
    }

    private void SetResources()
    {
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

    private void SetLight()
    {
        _resource[MaterialColor.Primary] = ColorPalettes[TonalPalettes.Primary][40].ToMedia();
        _resource[MaterialColor.OnPrimary] = ColorPalettes[TonalPalettes.Primary][100].ToMedia();
        _resource[MaterialColor.PrimaryContainer] = ColorPalettes[TonalPalettes.Primary][90].ToMedia();
        _resource[MaterialColor.OnPrimaryContainer] = ColorPalettes[TonalPalettes.Primary][10].ToMedia();

        _resource[MaterialColor.Secondary] = ColorPalettes[TonalPalettes.Secondary][40].ToMedia();
        _resource[MaterialColor.OnSecondary] = ColorPalettes[TonalPalettes.Secondary][100].ToMedia();
        _resource[MaterialColor.SecondaryContainer] = ColorPalettes[TonalPalettes.Secondary][90].ToMedia();
        _resource[MaterialColor.OnSecondaryContainer] = ColorPalettes[TonalPalettes.Secondary][10].ToMedia();

        _resource[MaterialColor.Tertiary] = ColorPalettes[TonalPalettes.Tertiary][40].ToMedia();
        _resource[MaterialColor.OnTertiary] = ColorPalettes[TonalPalettes.Tertiary][100].ToMedia();
        _resource[MaterialColor.TertiaryContainer] = ColorPalettes[TonalPalettes.Tertiary][90].ToMedia();
        _resource[MaterialColor.OnTertiaryContainer] = ColorPalettes[TonalPalettes.Tertiary][10].ToMedia();

        _resource[MaterialColor.Error] = ColorPalettes[TonalPalettes.Error][40].ToMedia();
        _resource[MaterialColor.OnError] = ColorPalettes[TonalPalettes.Error][100].ToMedia();
        _resource[MaterialColor.ErrorContainer] = ColorPalettes[TonalPalettes.Error][90].ToMedia();
        _resource[MaterialColor.OnErrorContainer] = ColorPalettes[TonalPalettes.Error][10].ToMedia();

        _resource[MaterialColor.PrimaryFixed] = ColorPalettes[TonalPalettes.Primary][90].ToMedia();
        _resource[MaterialColor.PrimaryFixedDim] = ColorPalettes[TonalPalettes.Primary][80].ToMedia();
        _resource[MaterialColor.OnPrimaryFixed] = ColorPalettes[TonalPalettes.Primary][10].ToMedia();
        _resource[MaterialColor.OnPrimaryFixedVariant] = ColorPalettes[TonalPalettes.Primary][30].ToMedia();

        _resource[MaterialColor.SecondaryFixed] = ColorPalettes[TonalPalettes.Secondary][90].ToMedia();
        _resource[MaterialColor.SecondaryFixedDim] = ColorPalettes[TonalPalettes.Secondary][80].ToMedia();
        _resource[MaterialColor.OnSecondaryFixed] = ColorPalettes[TonalPalettes.Secondary][10].ToMedia();
        _resource[MaterialColor.OnSecondaryFixedVariant] = ColorPalettes[TonalPalettes.Secondary][30].ToMedia();

        _resource[MaterialColor.TertiaryFixed] = ColorPalettes[TonalPalettes.Tertiary][90].ToMedia();
        _resource[MaterialColor.TertiaryFixedDim] = ColorPalettes[TonalPalettes.Tertiary][80].ToMedia();
        _resource[MaterialColor.OnTertiaryFixed] = ColorPalettes[TonalPalettes.Tertiary][10].ToMedia();
        _resource[MaterialColor.OnTertiaryFixedVariant] = ColorPalettes[TonalPalettes.Tertiary][30].ToMedia();

        _resource[MaterialColor.SurfaceDim] = ColorPalettes[TonalPalettes.Neutral][87].ToMedia();
        _resource[MaterialColor.Surface] = ColorPalettes[TonalPalettes.Neutral][98].ToMedia();
        _resource[MaterialColor.SurfaceBright] = ColorPalettes[TonalPalettes.Neutral][98].ToMedia();
        _resource[MaterialColor.SurfaceContainerLowest] = ColorPalettes[TonalPalettes.Neutral][100].ToMedia();
        _resource[MaterialColor.SurfaceContainerLow] = ColorPalettes[TonalPalettes.Neutral][96].ToMedia();
        _resource[MaterialColor.SurfaceContainer] = ColorPalettes[TonalPalettes.Neutral][94].ToMedia();
        _resource[MaterialColor.SurfaceContainerHigh] = ColorPalettes[TonalPalettes.Neutral][92].ToMedia();
        _resource[MaterialColor.SurfaceContainerHighest] = ColorPalettes[TonalPalettes.Neutral][90].ToMedia();
        _resource[MaterialColor.OnSurface] = ColorPalettes[TonalPalettes.Neutral][10].ToMedia();
        _resource[MaterialColor.OnSurfaceVariant] = ColorPalettes[TonalPalettes.NeutralVariant][30].ToMedia();
        _resource[MaterialColor.Outline] = ColorPalettes[TonalPalettes.NeutralVariant][50].ToMedia();
        _resource[MaterialColor.OutlineVariant] = ColorPalettes[TonalPalettes.NeutralVariant][80].ToMedia();

        _resource[MaterialColor.InverseSurface] = ColorPalettes[TonalPalettes.Neutral][20].ToMedia();
        _resource[MaterialColor.InverseOnSurface] = ColorPalettes[TonalPalettes.Neutral][95].ToMedia();
        _resource[MaterialColor.InversePrimary] = ColorPalettes[TonalPalettes.Primary][80].ToMedia();
        _resource[MaterialColor.Scrim] = ColorPalettes[TonalPalettes.Neutral][0].ToMedia();
        _resource[MaterialColor.Shadow] = ColorPalettes[TonalPalettes.Neutral][0].ToMedia();

        SetSolidBrush();
    }

    private void SetDark()
    {
        _resource[MaterialColor.Primary] = ColorPalettes[TonalPalettes.Primary][80].ToMedia();
        _resource[MaterialColor.OnPrimary] = ColorPalettes[TonalPalettes.Primary][20].ToMedia();
        _resource[MaterialColor.PrimaryContainer] = ColorPalettes[TonalPalettes.Primary][30].ToMedia();
        _resource[MaterialColor.OnPrimaryContainer] = ColorPalettes[TonalPalettes.Primary][90].ToMedia();

        _resource[MaterialColor.Secondary] = ColorPalettes[TonalPalettes.Secondary][80].ToMedia();
        _resource[MaterialColor.OnSecondary] = ColorPalettes[TonalPalettes.Secondary][20].ToMedia();
        _resource[MaterialColor.SecondaryContainer] = ColorPalettes[TonalPalettes.Secondary][30].ToMedia();
        _resource[MaterialColor.OnSecondaryContainer] = ColorPalettes[TonalPalettes.Secondary][90].ToMedia();

        _resource[MaterialColor.Tertiary] = ColorPalettes[TonalPalettes.Tertiary][80].ToMedia();
        _resource[MaterialColor.OnTertiary] = ColorPalettes[TonalPalettes.Tertiary][20].ToMedia();
        _resource[MaterialColor.TertiaryContainer] = ColorPalettes[TonalPalettes.Tertiary][30].ToMedia();
        _resource[MaterialColor.OnTertiaryContainer] = ColorPalettes[TonalPalettes.Tertiary][90].ToMedia();

        _resource[MaterialColor.Error] = ColorPalettes[TonalPalettes.Error][80].ToMedia();
        _resource[MaterialColor.OnError] = ColorPalettes[TonalPalettes.Error][20].ToMedia();
        _resource[MaterialColor.ErrorContainer] = ColorPalettes[TonalPalettes.Error][30].ToMedia();
        _resource[MaterialColor.OnErrorContainer] = ColorPalettes[TonalPalettes.Error][90].ToMedia();

        _resource[MaterialColor.PrimaryFixed] = ColorPalettes[TonalPalettes.Primary][90].ToMedia();
        _resource[MaterialColor.PrimaryFixedDim] = ColorPalettes[TonalPalettes.Primary][80].ToMedia();
        _resource[MaterialColor.OnPrimaryFixed] = ColorPalettes[TonalPalettes.Primary][10].ToMedia();
        _resource[MaterialColor.OnPrimaryFixedVariant] = ColorPalettes[TonalPalettes.Primary][30].ToMedia();

        _resource[MaterialColor.SecondaryFixed] = ColorPalettes[TonalPalettes.Secondary][90].ToMedia();
        _resource[MaterialColor.SecondaryFixedDim] = ColorPalettes[TonalPalettes.Secondary][80].ToMedia();
        _resource[MaterialColor.OnSecondaryFixed] = ColorPalettes[TonalPalettes.Secondary][10].ToMedia();
        _resource[MaterialColor.OnSecondaryFixedVariant] = ColorPalettes[TonalPalettes.Secondary][30].ToMedia();

        _resource[MaterialColor.TertiaryFixed] = ColorPalettes[TonalPalettes.Tertiary][90].ToMedia();
        _resource[MaterialColor.TertiaryFixedDim] = ColorPalettes[TonalPalettes.Tertiary][80].ToMedia();
        _resource[MaterialColor.OnTertiaryFixed] = ColorPalettes[TonalPalettes.Tertiary][10].ToMedia();
        _resource[MaterialColor.OnTertiaryFixedVariant] = ColorPalettes[TonalPalettes.Tertiary][30].ToMedia();

        _resource[MaterialColor.SurfaceDim] = ColorPalettes[TonalPalettes.Neutral][6].ToMedia();
        _resource[MaterialColor.Surface] = ColorPalettes[TonalPalettes.Neutral][6].ToMedia();
        _resource[MaterialColor.SurfaceBright] = ColorPalettes[TonalPalettes.Neutral][24].ToMedia();
        _resource[MaterialColor.SurfaceContainerLowest] = ColorPalettes[TonalPalettes.Neutral][4].ToMedia();
        _resource[MaterialColor.SurfaceContainerLow] = ColorPalettes[TonalPalettes.Neutral][10].ToMedia();
        _resource[MaterialColor.SurfaceContainer] = ColorPalettes[TonalPalettes.Neutral][12].ToMedia();
        _resource[MaterialColor.SurfaceContainerHigh] = ColorPalettes[TonalPalettes.Neutral][17].ToMedia();
        _resource[MaterialColor.SurfaceContainerHighest] = ColorPalettes[TonalPalettes.Neutral][22].ToMedia();
        _resource[MaterialColor.OnSurface] = ColorPalettes[TonalPalettes.Neutral][90].ToMedia();
        _resource[MaterialColor.OnSurfaceVariant] = ColorPalettes[TonalPalettes.NeutralVariant][80].ToMedia();
        _resource[MaterialColor.Outline] = ColorPalettes[TonalPalettes.NeutralVariant][60].ToMedia();
        _resource[MaterialColor.OutlineVariant] = ColorPalettes[TonalPalettes.NeutralVariant][30].ToMedia();

        _resource[MaterialColor.InverseSurface] = ColorPalettes[TonalPalettes.Neutral][90].ToMedia();
        _resource[MaterialColor.InverseOnSurface] = ColorPalettes[TonalPalettes.Neutral][20].ToMedia();
        _resource[MaterialColor.InversePrimary] = ColorPalettes[TonalPalettes.Primary][40].ToMedia();
        _resource[MaterialColor.Scrim] = ColorPalettes[TonalPalettes.Neutral][0].ToMedia();
        _resource[MaterialColor.Shadow] = ColorPalettes[TonalPalettes.Neutral][0].ToMedia();

        SetSolidBrush();
    }

    private void SetSolidBrush()
    {
        _resource[MaterialBrush.Primary] = new SolidColorBrush() { Color = _resource[MaterialColor.Primary].ToMedia() };
        _resource[MaterialBrush.OnPrimary] = new SolidColorBrush() { Color = _resource[MaterialColor.OnPrimary].ToMedia() };
        _resource[MaterialBrush.PrimaryContainer] = new SolidColorBrush() { Color = _resource[MaterialColor.PrimaryContainer].ToMedia() };
        _resource[MaterialBrush.OnPrimaryContainer] = new SolidColorBrush() { Color = _resource[MaterialColor.OnPrimaryContainer].ToMedia() };
        _resource[MaterialBrush.Secondary] = new SolidColorBrush() { Color = _resource[MaterialColor.Secondary].ToMedia() };
        _resource[MaterialBrush.OnSecondary] = new SolidColorBrush() { Color = _resource[MaterialColor.OnSecondary].ToMedia() };
        _resource[MaterialBrush.SecondaryContainer] = new SolidColorBrush() { Color = _resource[MaterialColor.SecondaryContainer].ToMedia() };
        _resource[MaterialBrush.OnSecondaryContainer] = new SolidColorBrush() { Color = _resource[MaterialColor.OnSecondaryContainer].ToMedia() };
        _resource[MaterialBrush.Tertiary] = new SolidColorBrush() { Color = _resource[MaterialColor.Tertiary].ToMedia() };
        _resource[MaterialBrush.OnTertiary] = new SolidColorBrush() { Color = _resource[MaterialColor.OnTertiary].ToMedia() };
        _resource[MaterialBrush.TertiaryContainer] = new SolidColorBrush() { Color = _resource[MaterialColor.TertiaryContainer].ToMedia() };
        _resource[MaterialBrush.OnTertiaryContainer] = new SolidColorBrush() { Color = _resource[MaterialColor.OnTertiaryContainer].ToMedia() };
        _resource[MaterialBrush.Error] = new SolidColorBrush() { Color = _resource[MaterialColor.Error].ToMedia() };
        _resource[MaterialBrush.OnError] = new SolidColorBrush() { Color = _resource[MaterialColor.OnError].ToMedia() };
        _resource[MaterialBrush.ErrorContainer] = new SolidColorBrush() { Color = _resource[MaterialColor.ErrorContainer].ToMedia() };
        _resource[MaterialBrush.OnErrorContainer] = new SolidColorBrush() { Color = _resource[MaterialColor.OnErrorContainer].ToMedia() };
        _resource[MaterialBrush.PrimaryFixed] = new SolidColorBrush() { Color = _resource[MaterialColor.PrimaryFixed].ToMedia() };
        _resource[MaterialBrush.PrimaryFixedDim] = new SolidColorBrush() { Color = _resource[MaterialColor.PrimaryFixedDim].ToMedia() };
        _resource[MaterialBrush.OnPrimaryFixed] = new SolidColorBrush() { Color = _resource[MaterialColor.OnPrimaryFixed].ToMedia() };
        _resource[MaterialBrush.OnPrimaryFixedVariant] = new SolidColorBrush() { Color = _resource[MaterialColor.OnPrimaryFixedVariant].ToMedia() };
        _resource[MaterialBrush.SecondaryFixed] = new SolidColorBrush() { Color = _resource[MaterialColor.SecondaryFixed].ToMedia() };
        _resource[MaterialBrush.SecondaryFixedDim] = new SolidColorBrush() { Color = _resource[MaterialColor.SecondaryFixedDim].ToMedia() };
        _resource[MaterialBrush.OnSecondaryFixed] = new SolidColorBrush() { Color = _resource[MaterialColor.OnSecondaryFixed].ToMedia() };
        _resource[MaterialBrush.OnSecondaryFixedVariant] = new SolidColorBrush() { Color = _resource[MaterialColor.OnSecondaryFixedVariant].ToMedia() };
        _resource[MaterialBrush.TertiaryFixed] = new SolidColorBrush() { Color = _resource[MaterialColor.TertiaryFixed].ToMedia() };
        _resource[MaterialBrush.TertiaryFixedDim] = new SolidColorBrush() { Color = _resource[MaterialColor.TertiaryFixedDim].ToMedia() };
        _resource[MaterialBrush.OnTertiaryFixed] = new SolidColorBrush() { Color = _resource[MaterialColor.OnTertiaryFixed].ToMedia() };
        _resource[MaterialBrush.OnTertiaryFixedVariant] = new SolidColorBrush() { Color = _resource[MaterialColor.OnTertiaryFixedVariant].ToMedia() };
        _resource[MaterialBrush.SurfaceDim] = new SolidColorBrush() { Color = _resource[MaterialColor.SurfaceDim].ToMedia() };
        _resource[MaterialBrush.Surface] = new SolidColorBrush() { Color = _resource[MaterialColor.Surface].ToMedia() };
        _resource[MaterialBrush.SurfaceBright] = new SolidColorBrush() { Color = _resource[MaterialColor.SurfaceBright].ToMedia() };
        _resource[MaterialBrush.SurfaceContainerLowest] = new SolidColorBrush() { Color = _resource[MaterialColor.SurfaceContainerLowest].ToMedia() };
        _resource[MaterialBrush.SurfaceContainerLow] = new SolidColorBrush() { Color = _resource[MaterialColor.SurfaceContainerLow].ToMedia() };
        _resource[MaterialBrush.SurfaceContainer] = new SolidColorBrush() { Color = _resource[MaterialColor.SurfaceContainer].ToMedia() };
        _resource[MaterialBrush.SurfaceContainerHigh] = new SolidColorBrush() { Color = _resource[MaterialColor.SurfaceContainerHigh].ToMedia() };
        _resource[MaterialBrush.SurfaceContainerHighest] = new SolidColorBrush() { Color = _resource[MaterialColor.SurfaceContainerHighest].ToMedia() };
        _resource[MaterialBrush.OnSurface] = new SolidColorBrush() { Color = _resource[MaterialColor.OnSurface].ToMedia() };
        _resource[MaterialBrush.OnSurfaceVariant] = new SolidColorBrush() { Color = _resource[MaterialColor.OnSurfaceVariant].ToMedia() };
        _resource[MaterialBrush.Outline] = new SolidColorBrush() { Color = _resource[MaterialColor.Outline].ToMedia() };
        _resource[MaterialBrush.OutlineVariant] = new SolidColorBrush() { Color = _resource[MaterialColor.OutlineVariant].ToMedia() };
        _resource[MaterialBrush.InverseSurface] = new SolidColorBrush() { Color = _resource[MaterialColor.InverseSurface].ToMedia() };
        _resource[MaterialBrush.InverseOnSurface] = new SolidColorBrush() { Color = _resource[MaterialColor.InverseOnSurface].ToMedia() };
        _resource[MaterialBrush.InversePrimary] = new SolidColorBrush() { Color = _resource[MaterialColor.InversePrimary].ToMedia() };
        _resource[MaterialBrush.Scrim] = new SolidColorBrush() { Color = _resource[MaterialColor.Scrim].ToMedia() };
        _resource[MaterialBrush.Shadow] = new SolidColorBrush() { Color = _resource[MaterialColor.Shadow].ToMedia() };
    }
}

internal static class DrawingExtension
{
    public static Color ToMedia(this System.Drawing.Color color) => Color.FromRgb(color.R, color.G, color.B);

    public static Color ToMedia(this object color)
    {
        var rgb = (Color)color;
        return Color.FromRgb(rgb.R, rgb.G, rgb.B);
    }

    public static System.Drawing.Color ToDrawing(this Color color) => System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
}