using PrismTest1.Views;
using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using ModuleA;
using Prism.Regions;
using System.Windows.Controls;
using PrismTest1.Infrastructure;
using System;

namespace PrismTest1
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(ModuleAModule));


            //Type moduleAType = typeof(ModuleAModule);
            //moduleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = moduleAType.Name,
            //    ModuleType = moduleAType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.WhenAvailable
            //});
        }

        /*protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog()
            {
                ModulePath = @"./Modules"
            };
            //return Prism.Modularity.ModuleCatalog.CreateFromXaml(new Uri("/PrismTest1;component/XamlCatalog.xaml", UriKind.Relative));
        }*/


        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new ConfigurationModuleCatalog();
        //}

        

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }

    }
}
