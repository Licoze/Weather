using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject;
using Ninject.Modules;
using Weather.BLL.Interfaces;
using Weather.BLL.Services;
using Weather.DAL.Infrastructure;

namespace Weather.BLL.Infrastructure
{ 
    public class DatabaseModule:NinjectModule
    {
        private readonly string _connectionStr;
        public DatabaseModule(string connectionStr)
        {
            _connectionStr = connectionStr;
        }
        public override void Load()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<BLLMappingProfile>();
            });
            var mapper = config.CreateMapper();
            Bind<WeatherDb>().ToSelf().WithConstructorArgument(_connectionStr);
            Bind<IHistoryService>().To<HistoryService>()
                                   .WithConstructorArgument("db",ctx=>ctx.Kernel.Get<WeatherDb>())
                                   .WithConstructorArgument("mapper", mapper);
            Bind<IWeatherService>().To<WeatherService>()
                                   .WithConstructorArgument("mapper", mapper);
               
        }
    }
}
