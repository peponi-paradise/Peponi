using Google.MaterialColorUtilities;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF.Colors;

public enum ColorMode
{
    Light,
    Dark,
    Auto
}

public static class ColorProvider
{
    private static ResourceDictionary? _resource;
    private static Dictionary<string, TonalPalette> _palettes;

    private const string Primary = "Primary";
    private const string Secondary = "Secondary";
    private const string Tertiary = "Tertiary";
    private const string Neutral = "Neutral";
    private const string NeutralVariant = "NeutralVariant";
    private const string Error = "Error";

    private static bool _useWindowsAccentColor = false;
    private static ColorMode _colorMode = ColorMode.Auto;

    static ColorProvider()
    {
        _palettes = new Dictionary<string, TonalPalette>
        {
            { Primary, new() },
            { Secondary, new() },
            { Tertiary, new() },
            { Neutral, new() },
            { NeutralVariant, new() },
            { Error, new(25, 84) }
        };

        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
    }

    private static void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        switch (e.Category)
        {
            case UserPreferenceCategory.General:
                if (_useWindowsAccentColor) CreatePalette(GetAccentColor(), null, null);
                SetResources(_colorMode);
                break;
        }
    }

    public static void UseWindowsAccentColor(ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = true;

        CreatePalette(GetAccentColor(), null, null);

        SetResources(colorMode);
    }

    public static void SetColors(Color color, ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = false;

        CreatePalette(color, null, null);

        SetResources(colorMode);
    }

    public static void SetColors(Color primary, Color secondary, Color tertiary, ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = false;

        CreatePalette(primary, secondary, tertiary);

        SetResources(colorMode);
    }

    public static bool SetColors(string xamlPath, ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = false;

        try
        {
            var res = new ResourceDictionary() { Source = new Uri(xamlPath, UriKind.RelativeOrAbsolute) };
            if (!res.Keys.CheckResourceKeys(_resource!)) return false;
            foreach (var item in res.Keys) _resource![item] = res[item];
        }
        catch
        {
            return false;
        }

        SetResources(colorMode);
        return true;
    }

    public static bool SetColors(Dictionary<string, object> collection, ColorMode colorMode = ColorMode.Auto)
    {
        _useWindowsAccentColor = false;

        if (collection is null) return false;
        else
        {
            if (!collection.Keys.CheckResourceKeys(_resource!)) return false;

            foreach (var item in collection) _resource![item.Key] = item.Value;
        }

        SetResources(colorMode);
        return true;
    }

    public static void SetColorMode(ColorMode colorMode) => SetResources(colorMode);

    internal static void InitializeInternal(ResourceDictionary resource)
    {
        _resource = resource;
        SetColors(Color.FromRgb(0x75, 0x75, 0x75), IsSystemLight() ? ColorMode.Light : ColorMode.Dark);
    }

    private static void CreatePalette(Color primary, Color? secondary, Color? tertiary)
    {
        _palettes[Primary] = new TonalPalette(ToDrawingColor(primary));
        var hue = _palettes[Primary].Hue;
        _palettes[Secondary] = secondary == null ? new TonalPalette(hue, 16) : new TonalPalette(ToDrawingColor((Color)secondary));
        _palettes[Tertiary] = tertiary == null ? new TonalPalette(hue + 60, 24) : new TonalPalette(ToDrawingColor((Color)tertiary));
        _palettes[Neutral] = new TonalPalette(hue, 4);
        _palettes[NeutralVariant] = new TonalPalette(hue, 8);
    }

    private static void SetResources(ColorMode colorMode)
    {
        if (_colorMode == ColorMode.Light || _colorMode == ColorMode.Dark)
        {
            if (_colorMode == colorMode) return;
        }

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
        _resource!["Color.Primary"] = ToMediaColor(_palettes[Primary][40]);
        _resource!["Color.OnPrimary"] = ToMediaColor(_palettes[Primary][100]);
        _resource!["Color.PrimaryContainer"] = ToMediaColor(_palettes[Primary][90]);
        _resource!["Color.OnPrimaryContainer"] = ToMediaColor(_palettes[Primary][10]);
        _resource!["Color.Secondary"] = ToMediaColor(_palettes[Secondary][40]);
        _resource!["Color.OnSecondary"] = ToMediaColor(_palettes[Secondary][100]);
        _resource!["Color.SecondaryContainer"] = ToMediaColor(_palettes[Secondary][90]);
        _resource!["Color.OnSecondaryContainer"] = ToMediaColor(_palettes[Secondary][10]);
        _resource!["Color.Tertiary"] = ToMediaColor(_palettes[Tertiary][40]);
        _resource!["Color.OnTertiary"] = ToMediaColor(_palettes[Tertiary][100]);
        _resource!["Color.TertiaryContainer"] = ToMediaColor(_palettes[Tertiary][90]);
        _resource!["Color.OnTertiaryContainer"] = ToMediaColor(_palettes[Tertiary][10]);
        _resource!["Color.Error"] = ToMediaColor(_palettes[Error][40]);
        _resource!["Color.OnError"] = ToMediaColor(_palettes[Error][100]);
        _resource!["Color.ErrorContainer"] = ToMediaColor(_palettes[Error][90]);
        _resource!["Color.OnErrorContainer"] = ToMediaColor(_palettes[Error][10]);
        _resource!["Color.PrimaryFixed"] = ToMediaColor(_palettes[Primary][90]);
        _resource!["Color.PrimaryFixedDim"] = ToMediaColor(_palettes[Primary][80]);
        _resource!["Color.OnPrimaryFixed"] = ToMediaColor(_palettes[Primary][10]);
        _resource!["Color.OnPrimaryFixedVariant"] = ToMediaColor(_palettes[Primary][30]);
        _resource!["Color.SecondaryFixed"] = ToMediaColor(_palettes[Secondary][90]);
        _resource!["Color.SecondaryFixedDim"] = ToMediaColor(_palettes[Secondary][80]);
        _resource!["Color.OnSecondaryFixed"] = ToMediaColor(_palettes[Secondary][10]);
        _resource!["Color.OnSecondaryFixedVariant"] = ToMediaColor(_palettes[Secondary][30]);
        _resource!["Color.TertiaryFixed"] = ToMediaColor(_palettes[Tertiary][90]);
        _resource!["Color.TertiaryFixedDim"] = ToMediaColor(_palettes[Tertiary][80]);
        _resource!["Color.OnTertiaryFixed"] = ToMediaColor(_palettes[Tertiary][10]);
        _resource!["Color.OnTertiaryFixedVariant"] = ToMediaColor(_palettes[Tertiary][30]);
        _resource!["Color.SurfaceDim"] = ToMediaColor(_palettes[Neutral][87]);
        _resource!["Color.Surface"] = ToMediaColor(_palettes[Neutral][98]);
        _resource!["Color.SurfaceBright"] = ToMediaColor(_palettes[Neutral][98]);
        _resource!["Color.SurfaceContainerLowest"] = ToMediaColor(_palettes[Neutral][100]);
        _resource!["Color.SurfaceContainerLow"] = ToMediaColor(_palettes[Neutral][96]);
        _resource!["Color.SurfaceContainer"] = ToMediaColor(_palettes[Neutral][94]);
        _resource!["Color.SurfaceContainerHigh"] = ToMediaColor(_palettes[Neutral][92]);
        _resource!["Color.SurfaceContainerHighest"] = ToMediaColor(_palettes[Neutral][90]);
        _resource!["Color.OnSurface"] = ToMediaColor(_palettes[Neutral][10]);
        _resource!["Color.OnSurfaceVariant"] = ToMediaColor(_palettes[NeutralVariant][30]);
        _resource!["Color.Outline"] = ToMediaColor(_palettes[NeutralVariant][50]);
        _resource!["Color.OutlineVariant"] = ToMediaColor(_palettes[NeutralVariant][80]);
        _resource!["Color.InverseSurface"] = ToMediaColor(_palettes[Neutral][20]);
        _resource!["Color.InverseOnSurface"] = ToMediaColor(_palettes[Neutral][95]);
        _resource!["Color.InversePrimary"] = ToMediaColor(_palettes[Primary][80]);
        _resource!["Color.Scrim"] = ToMediaColor(_palettes[Neutral][0]);
        _resource!["Color.Shadow"] = ToMediaColor(_palettes[Neutral][0]);

        _resource!["Brush.Primary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][40]) };
        _resource!["Brush.OnPrimary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][100]) };
        _resource!["Brush.PrimaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][90]) };
        _resource!["Brush.OnPrimaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][10]) };
        _resource!["Brush.Secondary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][40]) };
        _resource!["Brush.OnSecondary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][100]) };
        _resource!["Brush.SecondaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][90]) };
        _resource!["Brush.OnSecondaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][10]) };
        _resource!["Brush.Tertiary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][40]) };
        _resource!["Brush.OnTertiary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][100]) };
        _resource!["Brush.TertiaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][90]) };
        _resource!["Brush.OnTertiaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][10]) };
        _resource!["Brush.Error"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Error][40]) };
        _resource!["Brush.OnError"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Error][100]) };
        _resource!["Brush.ErrorContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Error][90]) };
        _resource!["Brush.OnErrorContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Error][10]) };
        _resource!["Brush.PrimaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][90]) };
        _resource!["Brush.PrimaryFixedDim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][80]) };
        _resource!["Brush.OnPrimaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][10]) };
        _resource!["Brush.OnPrimaryFixedVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][30]) };
        _resource!["Brush.SecondaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][90]) };
        _resource!["Brush.SecondaryFixedDim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][80]) };
        _resource!["Brush.OnSecondaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][10]) };
        _resource!["Brush.OnSecondaryFixedVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][30]) };
        _resource!["Brush.TertiaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][90]) };
        _resource!["Brush.TertiaryFixedDim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][80]) };
        _resource!["Brush.OnTertiaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][10]) };
        _resource!["Brush.OnTertiaryFixedVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][30]) };
        _resource!["Brush.SurfaceDim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][87]) };
        _resource!["Brush.Surface"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][98]) };
        _resource!["Brush.SurfaceBright"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][98]) };
        _resource!["Brush.SurfaceContainerLowest"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][100]) };
        _resource!["Brush.SurfaceContainerLow"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][96]) };
        _resource!["Brush.SurfaceContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][94]) };
        _resource!["Brush.SurfaceContainerHigh"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][92]) };
        _resource!["Brush.SurfaceContainerHighest"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][90]) };
        _resource!["Brush.OnSurface"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][10]) };
        _resource!["Brush.OnSurfaceVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[NeutralVariant][30]) };
        _resource!["Brush.Outline"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[NeutralVariant][50]) };
        _resource!["Brush.OutlineVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[NeutralVariant][80]) };
        _resource!["Brush.InverseSurface"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][20]) };
        _resource!["Brush.InverseOnSurface"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][95]) };
        _resource!["Brush.InversePrimary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][80]) };
        _resource!["Brush.Scrim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][0]) };
        _resource!["Brush.Shadow"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][0]) };
    }

    private static void SetDark()
    {
        _resource!["Color.Primary"] = ToMediaColor(_palettes[Primary][80]);
        _resource!["Color.OnPrimary"] = ToMediaColor(_palettes[Primary][20]);
        _resource!["Color.PrimaryContainer"] = ToMediaColor(_palettes[Primary][30]);
        _resource!["Color.OnPrimaryContainer"] = ToMediaColor(_palettes[Primary][90]);
        _resource!["Color.Secondary"] = ToMediaColor(_palettes[Secondary][80]);
        _resource!["Color.OnSecondary"] = ToMediaColor(_palettes[Secondary][20]);
        _resource!["Color.SecondaryContainer"] = ToMediaColor(_palettes[Secondary][30]);
        _resource!["Color.OnSecondaryContainer"] = ToMediaColor(_palettes[Secondary][90]);
        _resource!["Color.Tertiary"] = ToMediaColor(_palettes[Tertiary][80]);
        _resource!["Color.OnTertiary"] = ToMediaColor(_palettes[Tertiary][20]);
        _resource!["Color.TertiaryContainer"] = ToMediaColor(_palettes[Tertiary][30]);
        _resource!["Color.OnTertiaryContainer"] = ToMediaColor(_palettes[Tertiary][90]);
        _resource!["Color.Error"] = ToMediaColor(_palettes[Error][80]);
        _resource!["Color.OnError"] = ToMediaColor(_palettes[Error][20]);
        _resource!["Color.ErrorContainer"] = ToMediaColor(_palettes[Error][30]);
        _resource!["Color.OnErrorContainer"] = ToMediaColor(_palettes[Error][90]);
        _resource!["Color.PrimaryFixed"] = ToMediaColor(_palettes[Primary][90]);
        _resource!["Color.PrimaryFixedDim"] = ToMediaColor(_palettes[Primary][80]);
        _resource!["Color.OnPrimaryFixed"] = ToMediaColor(_palettes[Primary][10]);
        _resource!["Color.OnPrimaryFixedVariant"] = ToMediaColor(_palettes[Primary][30]);
        _resource!["Color.SecondaryFixed"] = ToMediaColor(_palettes[Secondary][90]);
        _resource!["Color.SecondaryFixedDim"] = ToMediaColor(_palettes[Secondary][80]);
        _resource!["Color.OnSecondaryFixed"] = ToMediaColor(_palettes[Secondary][10]);
        _resource!["Color.OnSecondaryFixedVariant"] = ToMediaColor(_palettes[Secondary][30]);
        _resource!["Color.TertiaryFixed"] = ToMediaColor(_palettes[Tertiary][90]);
        _resource!["Color.TertiaryFixedDim"] = ToMediaColor(_palettes[Tertiary][80]);
        _resource!["Color.OnTertiaryFixed"] = ToMediaColor(_palettes[Tertiary][10]);
        _resource!["Color.OnTertiaryFixedVariant"] = ToMediaColor(_palettes[Tertiary][30]);
        _resource!["Color.SurfaceDim"] = ToMediaColor(_palettes[Neutral][6]);
        _resource!["Color.Surface"] = ToMediaColor(_palettes[Neutral][6]);
        _resource!["Color.SurfaceBright"] = ToMediaColor(_palettes[Neutral][24]);
        _resource!["Color.SurfaceContainerLowest"] = ToMediaColor(_palettes[Neutral][4]);
        _resource!["Color.SurfaceContainerLow"] = ToMediaColor(_palettes[Neutral][10]);
        _resource!["Color.SurfaceContainer"] = ToMediaColor(_palettes[Neutral][12]);
        _resource!["Color.SurfaceContainerHigh"] = ToMediaColor(_palettes[Neutral][17]);
        _resource!["Color.SurfaceContainerHighest"] = ToMediaColor(_palettes[Neutral][22]);
        _resource!["Color.OnSurface"] = ToMediaColor(_palettes[Neutral][90]);
        _resource!["Color.OnSurfaceVariant"] = ToMediaColor(_palettes[NeutralVariant][80]);
        _resource!["Color.Outline"] = ToMediaColor(_palettes[NeutralVariant][60]);
        _resource!["Color.OutlineVariant"] = ToMediaColor(_palettes[NeutralVariant][30]);
        _resource!["Color.InverseSurface"] = ToMediaColor(_palettes[Neutral][90]);
        _resource!["Color.InverseOnSurface"] = ToMediaColor(_palettes[Neutral][20]);
        _resource!["Color.InversePrimary"] = ToMediaColor(_palettes[Primary][40]);
        _resource!["Color.Scrim"] = ToMediaColor(_palettes[Neutral][0]);
        _resource!["Color.Shadow"] = ToMediaColor(_palettes[Neutral][0]);

        _resource!["Brush.Primary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][80]) };
        _resource!["Brush.OnPrimary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][20]) };
        _resource!["Brush.PrimaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][30]) };
        _resource!["Brush.OnPrimaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][90]) };
        _resource!["Brush.Secondary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][80]) };
        _resource!["Brush.OnSecondary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][20]) };
        _resource!["Brush.SecondaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][30]) };
        _resource!["Brush.OnSecondaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][90]) };
        _resource!["Brush.Tertiary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][80]) };
        _resource!["Brush.OnTertiary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][20]) };
        _resource!["Brush.TertiaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][30]) };
        _resource!["Brush.OnTertiaryContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][90]) };
        _resource!["Brush.Error"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Error][80]) };
        _resource!["Brush.OnError"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Error][20]) };
        _resource!["Brush.ErrorContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Error][30]) };
        _resource!["Brush.OnErrorContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Error][90]) };
        _resource!["Brush.PrimaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][90]) };
        _resource!["Brush.PrimaryFixedDim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][80]) };
        _resource!["Brush.OnPrimaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][10]) };
        _resource!["Brush.OnPrimaryFixedVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][30]) };
        _resource!["Brush.SecondaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][90]) };
        _resource!["Brush.SecondaryFixedDim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][80]) };
        _resource!["Brush.OnSecondaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][10]) };
        _resource!["Brush.OnSecondaryFixedVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Secondary][30]) };
        _resource!["Brush.TertiaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][90]) };
        _resource!["Brush.TertiaryFixedDim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][80]) };
        _resource!["Brush.OnTertiaryFixed"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][10]) };
        _resource!["Brush.OnTertiaryFixedVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Tertiary][30]) };
        _resource!["Brush.SurfaceDim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][6]) };
        _resource!["Brush.Surface"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][6]) };
        _resource!["Brush.SurfaceBright"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][24]) };
        _resource!["Brush.SurfaceContainerLowest"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][4]) };
        _resource!["Brush.SurfaceContainerLow"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][10]) };
        _resource!["Brush.SurfaceContainer"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][12]) };
        _resource!["Brush.SurfaceContainerHigh"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][17]) };
        _resource!["Brush.SurfaceContainerHighest"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][22]) };
        _resource!["Brush.OnSurface"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][90]) };
        _resource!["Brush.OnSurfaceVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[NeutralVariant][80]) };
        _resource!["Brush.Outline"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[NeutralVariant][60]) };
        _resource!["Brush.OutlineVariant"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[NeutralVariant][30]) };
        _resource!["Brush.InverseSurface"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][90]) };
        _resource!["Brush.InverseOnSurface"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][20]) };
        _resource!["Brush.InversePrimary"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Primary][40]) };
        _resource!["Brush.Scrim"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][0]) };
        _resource!["Brush.Shadow"] = new SolidColorBrush() { Color = ToMediaColor(_palettes[Neutral][0]) };
    }

    private static Color ToMediaColor(System.Drawing.Color color) => Color.FromRgb(color.R, color.G, color.B);

    private static System.Drawing.Color ToDrawingColor(Color color) => System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
}