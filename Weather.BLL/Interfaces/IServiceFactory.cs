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
    public interface IServiceFactory
    {
        IHistoryService CreateHistoryService();
        IWeatherService CreateWeatherService();
        
    }
}
