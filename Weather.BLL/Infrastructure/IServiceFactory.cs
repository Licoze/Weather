using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Weather.BLL.Interfaces;
using Weather.DAL.Infrastructure;

namespace Weather.BLL.Infrastructure
{
    interface IServiceFactory
    {
        IHistoryService CreateHistoryService(WeatherDb db, IMapper mapper);
        IWeatherService CreateWeatherService(WeatherDb db, IMapper mapper);

    }
}
