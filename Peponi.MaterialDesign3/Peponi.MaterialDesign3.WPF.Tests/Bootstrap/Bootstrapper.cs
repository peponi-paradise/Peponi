using Peponi.MaterialDesign3.WPF.Tests.Define.Constants;
using Peponi.MaterialDesign3.WPF.Tests.View.Components;
using Peponi.MaterialDesign3.WPF.Tests.View.Windows;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace Peponi.MaterialDesign3.WPF.Tests.Bootstrap;

public class Bootstrapper : PrismBootstrapper
{
    protected override void ConfigureViewModelLocator()
    {
        base.ConfigureViewModelLocator();

        ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
        {
            var assemblyName = viewType.Assembly.GetName().Name;
            var nameSpaces = viewType.FullName!.Split('.');
            var nameSpace = nameSpaces[nameSpaces.Length - 2];
            var viewModelName = $"{assemblyName}.{Assemblies.ViewModel}.{nameSpace}.{viewType.Name}{Assemblies.ViewModel}, {assemblyName}";
            return Type.GetType(viewModelName);
        });
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        base.ConfigureModuleCatalog(moduleCatalog);
    }

    protected override DependencyObject CreateShell()
    {
        // Region register
        var regionManager = Container.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion<Navigator>(Regions.Navigation);
        regionManager.RegisterViewWithRegion<View.Pages.Colors>(Regions.View);
        regionManager.RegisterViewWithRegion<View.Pages.Fonts>(Regions.View);

        // Create main window
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Configure objects (Singleton, Scoped, etc...)

        // GUI

        containerRegistry.RegisterSingleton<View.Pages.Colors>();
        containerRegistry.RegisterSingleton<View.Pages.Fonts>();

        // Navigation

        containerRegistry.RegisterForNavigation<View.Pages.Colors>(Regions.View);
        containerRegistry.RegisterForNavigation<View.Pages.Fonts>(Regions.View);
    }
}