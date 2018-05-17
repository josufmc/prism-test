using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using PrismTest1.Infrastructure;
using PrismTest1.People.ViewModels;
using PrismTest1.People.Views;

namespace PrismTest1.People
{
    public class PeopleModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;


        public PeopleModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            container.RegisterType<IPersonViewModel, PersonViewModel>();
            container.RegisterType<IPersonView, PersonView>();

            var vm = container.Resolve<IPersonViewModel>();
            regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);
        }
    }
}
