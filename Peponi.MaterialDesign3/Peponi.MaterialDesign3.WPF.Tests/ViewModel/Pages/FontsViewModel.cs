using Peponi.SourceGenerators;

namespace Peponi.MaterialDesign3.WPF.Tests.ViewModel.Pages;

[NotifyInterface]
public partial class FontsViewModel
{
    [Command]
    private void ChangeFont(string name) => MaterialTheme.Current[MaterialFont.FontFamily] = FontHelper.GetFontFamily(name);
}