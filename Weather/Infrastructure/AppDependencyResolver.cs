using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Configuring.Automapper.Profiles;
using Ninject;
using Ninject.Extensions.Factory;
using Weather.BLL.Infrastructure;
using Weather.BLL.Interfaces;
using Weather.BLL.Services;

namespace Weather.Infrastructure
{
    public class AppDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public AppDependencyResolver(IKernel kernelParam)
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PLMappingProfile>();
                cfg.AddProfile<BLLMappingProfile>();
            });
            
            var mapper = config.CreateMapper();
            kernel.Bind<IServiceFactory>().ToFactory();
            kernel.Bind<IMapper>().ToConstant(mapper);
        }
    }
}
