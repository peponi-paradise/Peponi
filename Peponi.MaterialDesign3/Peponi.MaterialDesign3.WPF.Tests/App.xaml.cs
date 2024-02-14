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
        public App()
        {
            MaterialTheme.SetPalettes(Color.FromArgb(255, 0x75, 0x75, 0x75));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper bootstrap = new();
            bootstrap.Run();

            //MaterialTheme.UseWindowsAccentColor();
            MaterialTheme.SetFontFamily("RobotoSerif");
            //Debug.WriteLine(MaterialTheme.ThemeColors![MaterialBrush.OnSecondary]);
            MaterialTheme.ThemeColors[MaterialBrush.OnSecondary] = Brushes.Magenta;
            //Debug.WriteLine(MaterialTheme.ThemeColors![MaterialBrush.OnSecondary]);
            Debug.WriteLine(MaterialTheme.Palettes[Google.MaterialColorUtilities.TonalPalettes.Primary][80]);
        }
    }
}