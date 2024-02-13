using Peponi.MaterialDesign3.WPF.Tests.Bootstrap;
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

            //MaterialTheme.UseWindowsAccentColor();
            MaterialTheme.SetFontFamily("RobotoSerif");
            //Debug.WriteLine(MaterialTheme.ThemeColors![MaterialBrush.OnSecondary]);
            MaterialTheme.ThemeColors![MaterialBrush.OnSecondary] = Brushes.Magenta;
            //Debug.WriteLine(MaterialTheme.ThemeColors![MaterialBrush.OnSecondary]);
        }
    }
}