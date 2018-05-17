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

            var vm = container.Resolve<IContentAViewModel>();
            vm.Message = "First view";
            IRegion region = regionManager.Regions[RegionNames.ContentRegion];
            region.Add(vm.View);
            region.Deactivate(vm.View);

            var vm2 = container.Resolve<IContentAViewModel>();
            vm2.Message = "Second view";
            region.Add(vm2.View);



            //regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
