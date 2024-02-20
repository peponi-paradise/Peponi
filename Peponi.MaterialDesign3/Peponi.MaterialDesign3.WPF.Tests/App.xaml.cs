using Peponi.MaterialDesign3.WPF.Tests.Bootstrap;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF.Tests
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper bootstrap = new();
            bootstrap.Run();

            //MaterialTheme.Current.ColorMode = ColorMode.Light;
            MaterialTheme.Current.Primary = Colors.Magenta;
            MaterialTheme.Current.Secondary = Color.FromArgb(0xFF, 0x36, 0x58, 0xC3);
            MaterialTheme.Current.Tertiary = Colors.MediumSeaGreen;
            MaterialTheme.Current.ColorMode = ColorMode.Auto;
            MaterialTheme.Current.UseWindowsAccentColor = false;

            MaterialTheme.Current.FontFamily = FontHelper.GetFontFamily("RobotoFlex");
            MaterialTheme.Current.SecondaryFontFamily = FontHelper.GetFontFamily("RobotoSerif");
            MaterialTheme.Current.FontFamily = FontHelper.GetFontFamily("Microsoft Sans Serif");
            //MaterialTheme.Current[MaterialFont.FontFamily] = FontHelper.GetFontFamily(MaterialFont.DefaultFontFamily.Pretendard);
        }
    }
}