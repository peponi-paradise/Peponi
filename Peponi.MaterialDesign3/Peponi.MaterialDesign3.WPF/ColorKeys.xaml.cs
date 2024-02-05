using Peponi.MaterialDesign3.WPF.Colors;
using System.Windows;

namespace Peponi.MaterialDesign3.WPF;

public partial class ColorKeys : ResourceDictionary
{
    public ColorKeys()
    {
        InitializeComponent();
        ColorProvider.InitializeInternal(this);
    }
}