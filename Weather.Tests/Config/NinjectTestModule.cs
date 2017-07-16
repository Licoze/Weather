using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Weather.BLL.Infrastructure;
using Weather.BLL.Interfaces;
using Weather.BLL.Services;
using Weather.DAL.Infrastructure;
using Weather.DAL.Interfaces;

namespace Weather.Tests.Config
{
    public class NinjectTestModule:NinjectModule
    {
        public override void Load()
        {
            Bind<WeatherDb>().ToSelf().WithConstructorArgument("TestDB");
            Bind<IUnitOfWork>().To<WeatherUoW>();
            Bind<IHistoryService>().To<HistoryService>()
                .WithConstructorArgument("uof", ctx => ctx.Kernel.Get<WeatherDb>());
            Bind<IWeatherService>().To<WeatherService>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            var mapper = config.CreateMapper();
            Bind<IServiceFactory>().ToFactory();
            Bind<IMapper>().ToConstant(mapper);
        }
    }
}
