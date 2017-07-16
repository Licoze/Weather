using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Weather.DAL.Infrastructure;

namespace Configuring.Ninject.Modules
{
    public class DALModule:NinjectModule
    {
        private readonly string _connectionStr;
        public DALModule(string connectionStr)
        {
            _connectionStr = connectionStr;
        }

        public override void Load()
        {
            Bind<WeatherDb>().ToSelf().WithConstructorArgument(_connectionStr);
        }
    }
}
