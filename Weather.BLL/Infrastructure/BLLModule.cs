using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Weather.BLL.Interfaces;
using Weather.BLL.Services;

namespace Weather.BLL.Infrastructure
{
    class BLLModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IHistoryService>().To<HistoryService>();
            Bind<IWeatherService>().To<WeatherService>();
            Bind<IServiceFactory>().ToFactory();

        }

    }
}
