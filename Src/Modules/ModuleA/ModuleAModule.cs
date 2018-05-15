using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using PrismTest1.Infrastructure;

namespace ModuleA
{
    [Module(ModuleName ="ModuleA", OnDemand =true)]
    public class ModuleAModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;


        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));

            IRegion region = regionManager.Regions[RegionNames.BreadcrumbRegion];
            region.Add(container.Resolve<ToolbarView>());
            region.Add(container.Resolve<ToolbarView>());

            regionManager.RegisterViewWithRegion(RegionNames.BreadcrumbRegion, typeof(ToolbarView));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
