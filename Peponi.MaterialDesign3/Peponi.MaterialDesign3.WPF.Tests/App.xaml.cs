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

            MaterialTheme.Current.ColorMode = ColorMode.Light;
            MaterialTheme.Current.Primary = Color.FromArgb(255, 0x95, 0x89, 0xa1);
            //MaterialTheme.Current[MaterialFont.FontFamily] = FontHelper.GetFontFamily(MaterialFont.DefaultFontFamily.Pretendard);
            //Debug.WriteLine(MaterialTheme.Current.ColorPalettes[Google.MaterialColorUtilities.TonalPalettes.Primary][80]);
        }
    }
}