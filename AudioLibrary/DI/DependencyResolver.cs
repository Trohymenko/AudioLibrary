using System;
using System.Collections.Generic;
using Ninject;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System.Web.Mvc;

namespace AudioLibrary.DI
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IGetInfoService>().To<GetInfoService>().WithConstructorArgument("TracksDB");
            kernel.Bind<IModifyService>().To<ModifyService>().WithConstructorArgument("TracksDB");
            kernel.Bind<ISearchService>().To<SearchService>().WithConstructorArgument("TracksDB");
        }
    }
}