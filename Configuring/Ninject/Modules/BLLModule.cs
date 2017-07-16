using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Configuring.Automapper.Profiles;
using Ninject;
using Ninject.Modules;
using Weather.BLL.Infrastructure;
using Weather.BLL.Interfaces;
using Weather.BLL.Services;
using Weather.DAL.Infrastructure;
using Weather.DAL.Interfaces;

namespace Configuring.Ninject.Modules
{ 
    public class BLLModule:NinjectModule
    {
        public override void Load()
        {
            
            Bind<IUnitOfWork>().To<WeatherUoW>();
            Bind<IHistoryService>().To<HistoryService>()
                                   .WithConstructorArgument("uof", ctx => ctx.Kernel.Get<WeatherDb>());
            Bind<IWeatherService>().To<WeatherService>();

        }
    }
}
