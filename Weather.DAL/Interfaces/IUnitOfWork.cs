using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.DAL.Models;

namespace Weather.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<City> Cities { get; }
        IRepository<Forecast> Forecasts { get; }
        IRepository<SearchHistory> Histories { get; }
        IRepository<WeatherUnit> WeatherUnits { get; }
        int Save();
        Task<int> SaveAsync();
    }
}
