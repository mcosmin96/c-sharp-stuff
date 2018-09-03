using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using PrismWpfStuff.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleOne
{
    public class ModuleOneModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleOneModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];

            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());

            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
