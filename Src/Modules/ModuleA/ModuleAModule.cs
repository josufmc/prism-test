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
            container.RegisterType<ToolbarView>();
            container.RegisterType<IContentAView, ContentView>();
            container.RegisterType<IContentAViewModel, ContentAViewModel>();

            regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
