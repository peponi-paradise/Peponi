using Peponi.MaterialDesign3.WPF.Colors;
using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF;

public partial class MaterialThemeColor : ResourceDictionary
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
                ChangeOption();
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
                ChangeOption();
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
                ChangeOption();
            }
        }
    }

    private ColorMode _mode = ColorMode.Auto;

    public ColorMode ColorMode
    {
        get => _mode;
        set
        {
            if (_mode != value)
            {
                _mode = value;
                ChangeOption();
            }
        }
    }

    public MaterialThemeColor()
    {
        InitializeComponent();
        ColorProvider.InitializeInternal(this, Primary, Secondary, Tertiary, ColorMode);
    }

    private void ChangeOption()
    {
        ColorProvider.SetPalettes(Primary, Secondary, Tertiary, ColorMode);
    }
}