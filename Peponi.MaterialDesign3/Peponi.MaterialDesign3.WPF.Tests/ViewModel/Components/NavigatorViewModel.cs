using Peponi.MaterialDesign3.WPF.Tests.Define.Constants;
using Peponi.SourceGenerators;
using Prism.Regions;

namespace Peponi.MaterialDesign3.WPF.Tests.ViewModel.Components;

[NotifyInterface]
public partial class NavigatorViewModel
{
    private readonly IRegionManager? _regionManager;

    public NavigatorViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    [Command]
    private void Navigator(string viewName) => _regionManager?.RequestNavigate(Regions.View, viewName, NavigationResult);

    private void NavigationResult(NavigationResult result)
    { }
}