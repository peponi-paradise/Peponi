namespace Peponi.MaterialDesign3.WPF;

public static class MaterialColor
{
    private const string ColorPrefix = "Color.";

    public const string Primary = $"{ColorPrefix}{nameof(Primary)}";
    public const string OnPrimary = $"{ColorPrefix}{nameof(OnPrimary)}";
    public const string PrimaryContainer = $"{ColorPrefix}{nameof(PrimaryContainer)}";
    public const string OnPrimaryContainer = $"{ColorPrefix}{nameof(OnPrimaryContainer)}";

    public const string Secondary = $"{ColorPrefix}{nameof(Secondary)}";
    public const string OnSecondary = $"{ColorPrefix}{nameof(OnSecondary)}";
    public const string SecondaryContainer = $"{ColorPrefix}{nameof(SecondaryContainer)}";
    public const string OnSecondaryContainer = $"{ColorPrefix}{nameof(OnSecondaryContainer)}";

    public const string Tertiary = $"{ColorPrefix}{nameof(Tertiary)}";
    public const string OnTertiary = $"{ColorPrefix}{nameof(OnTertiary)}";
    public const string TertiaryContainer = $"{ColorPrefix}{nameof(TertiaryContainer)}";
    public const string OnTertiaryContainer = $"{ColorPrefix}{nameof(OnTertiaryContainer)}";

    public const string Error = $"{ColorPrefix}{nameof(Error)}";
    public const string OnError = $"{ColorPrefix}{nameof(OnError)}";
    public const string ErrorContainer = $"{ColorPrefix}{nameof(ErrorContainer)}";
    public const string OnErrorContainer = $"{ColorPrefix}{nameof(OnErrorContainer)}";

    public const string PrimaryFixed = $"{ColorPrefix}{nameof(PrimaryFixed)}";
    public const string PrimaryFixedDim = $"{ColorPrefix}{nameof(PrimaryFixedDim)}";
    public const string OnPrimaryFixed = $"{ColorPrefix}{nameof(OnPrimaryFixed)}";
    public const string OnPrimaryFixedVariant = $"{ColorPrefix}{nameof(OnPrimaryFixedVariant)}";

    public const string SecondaryFixed = $"{ColorPrefix}{nameof(SecondaryFixed)}";
    public const string SecondaryFixedDim = $"{ColorPrefix}{nameof(SecondaryFixedDim)}";
    public const string OnSecondaryFixed = $"{ColorPrefix}{nameof(OnSecondaryFixed)}";
    public const string OnSecondaryFixedVariant = $"{ColorPrefix}{nameof(OnSecondaryFixedVariant)}";

    public const string TertiaryFixed = $"{ColorPrefix}{nameof(TertiaryFixed)}";
    public const string TertiaryFixedDim = $"{ColorPrefix}{nameof(TertiaryFixedDim)}";
    public const string OnTertiaryFixed = $"{ColorPrefix}{nameof(OnTertiaryFixed)}";
    public const string OnTertiaryFixedVariant = $"{ColorPrefix}{nameof(OnTertiaryFixedVariant)}";

    public const string SurfaceDim = $"{ColorPrefix}{nameof(SurfaceDim)}";
    public const string Surface = $"{ColorPrefix}{nameof(Surface)}";
    public const string SurfaceBright = $"{ColorPrefix}{nameof(SurfaceBright)}";

    public const string SurfaceContainerLowest = $"{ColorPrefix}{nameof(SurfaceContainerLowest)}";
    public const string SurfaceContainerLow = $"{ColorPrefix}{nameof(SurfaceContainerLow)}";
    public const string SurfaceContainer = $"{ColorPrefix}{nameof(SurfaceContainer)}";
    public const string SurfaceContainerHigh = $"{ColorPrefix}{nameof(SurfaceContainerHigh)}";
    public const string SurfaceContainerHighest = $"{ColorPrefix}{nameof(SurfaceContainerHighest)}";

    public const string OnSurface = $"{ColorPrefix}{nameof(OnSurface)}";
    public const string OnSurfaceVariant = $"{ColorPrefix}{nameof(OnSurfaceVariant)}";

    public const string Outline = $"{ColorPrefix}{nameof(Outline)}";
    public const string OutlineVariant = $"{ColorPrefix}{nameof(OutlineVariant)}";

    public const string InverseSurface = $"{ColorPrefix}{nameof(InverseSurface)}";
    public const string InverseOnSurface = $"{ColorPrefix}{nameof(InverseOnSurface)}";
    public const string InversePrimary = $"{ColorPrefix}{nameof(InversePrimary)}";

    public const string Scrim = $"{ColorPrefix}{nameof(Scrim)}";
    public const string Shadow = $"{ColorPrefix}{nameof(Shadow)}";
}

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