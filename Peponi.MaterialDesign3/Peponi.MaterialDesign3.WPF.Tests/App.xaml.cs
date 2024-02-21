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

            //MaterialTheme.Current.Primary = Colors.Magenta;
            //MaterialTheme.Current.Secondary = Color.FromArgb(0xFF, 0x36, 0x58, 0xC3);
            //MaterialTheme.Current.Tertiary = Colors.MediumSeaGreen;
            //MaterialTheme.Current.ColorMode = ColorMode.Auto;
            //MaterialTheme.Current.UseWindowsAccentColor = false;
            //Debug.WriteLine(MaterialTheme.Current.ColorPalettes[Google.MaterialColorUtilities.TonalPalettes.Primary][40]);

            //MaterialTheme.Current.FontFamily = FontHelper.GetFontFamily("RobotoFlex");
            //MaterialTheme.Current.SecondaryFontFamily = FontHelper.GetFontFamily("RobotoSerif");
            //MaterialTheme.Current.TertiaryFontFamily = FontHelper.GetFontFamily("Microsoft Sans Serif");

            //MaterialTheme.Current[MaterialBrush.Primary] = Brushes.Aqua;
            //MaterialTheme.Current[MaterialBrush.Secondary] = Brushes.Crimson;
            //MaterialTheme.Current[MaterialBrush.Tertiary] = Brushes.Beige;

            //MaterialTheme.Current[MaterialFont.FontFamily] = FontHelper.GetFontFamily("Microsoft Sans Serif");
            //MaterialTheme.Current[MaterialFont.SecondaryFontFamily] = FontHelper.GetFontFamily("Consolas");
            //MaterialTheme.Current[MaterialFont.TertiaryFontFamily] = FontHelper.GetFontFamily("Arial");

            //MaterialTheme.Current.SetPalettes(Colors.DeepPink);
            //MaterialTheme.Current.SetPalettes(Colors.DeepPink, Colors.LemonChiffon, Colors.SaddleBrown);
            //MaterialTheme.Current.LoadXaml(@"MaterialThemeSetting.xaml");
            //Dictionary<string, object> materialThemeSetting = new()
            //{
            //    { MaterialColor.Primary, Colors.Chocolate },
            //    { MaterialBrush.Primary, Brushes.DarkSalmon },
            //    { MaterialBrush.OnPrimary, Brushes.Gray },
            //    { MaterialFont.FontFamily, FontHelper.GetFontFamily("Arial")! }
            //};
            //MaterialTheme.Current.SetCollection(materialThemeSetting);

            //var fontFamily = FontHelper.GetFontFamily("Consolas");
            //fontFamily = FontHelper.GetFontFamily("Pretendard Variable", @$"{Environment.CurrentDirectory}\Pretendard.ttf");
        }
    }
}