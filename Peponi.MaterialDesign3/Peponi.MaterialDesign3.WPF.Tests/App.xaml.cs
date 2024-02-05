using Peponi.MaterialDesign3.WPF.Tests.Bootstrap;
using System.Windows;

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

            ThemeProvider.UseWindowsAccentColor();
            ThemeProvider.SetFontFamily("RobotoSerif");
        }
    }
}