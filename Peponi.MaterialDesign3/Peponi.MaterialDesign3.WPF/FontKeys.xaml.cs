using Peponi.MaterialDesign3.WPF.Fonts;
using System.Windows;

namespace Peponi.MaterialDesign3.WPF;

public partial class FontKeys : ResourceDictionary
{
    public const string DisplayLarge = nameof(DisplayLarge);
    public const string DisplayMedium = nameof(DisplayMedium);
    public const string DisplaySmall = nameof(DisplaySmall);

    public const string HeadlineLarge = nameof(HeadlineLarge);
    public const string HeadlineMedium = nameof(HeadlineMedium);
    public const string HeadlineSmall = nameof(HeadlineSmall);

    public const string TitleLarge = nameof(TitleLarge);
    public const string TitleMedium = nameof(TitleMedium);
    public const string TitleSmall = nameof(TitleSmall);

    public const string LabelLarge = nameof(LabelLarge);
    public const string LabelMedium = nameof(LabelMedium);
    public const string LabelSmall = nameof(LabelSmall);

    public const string BodyLarge = nameof(BodyLarge);
    public const string BodyMedium = nameof(BodyMedium);
    public const string BodySmall = nameof(BodySmall);

    public FontKeys()
    {
        InitializeComponent();
        FontProvider.InitializeInternal(this);
    }
}