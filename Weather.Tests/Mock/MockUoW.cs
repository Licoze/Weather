using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.DAL.Infrastructure;
using Weather.DAL.Interfaces;
using Weather.DAL.Models;
using Weather.DAL.Repositories;

namespace Weather.Tests.Mock
{
    public class MockUoW:IUnitOfWork
    {
        private MockRepository<City> _cities;
        private MockRepository<Forecast> _forecasts;
        private MockRepository<SearchHistory> _histories;
        private MockRepository<WeatherUnit> _weatherUnits;
        private bool _disposed;

        public IRepository<City> Cities 
        {
            get
            {
                _cities = _cities ?? new MockRepository<City>();
                return _cities;
            }
        }

        public IRepository<Forecast> Forecasts
        {
            get
            {
                _forecasts = _forecasts ?? new MockRepository<Forecast>();
                return _forecasts;
            }
        }

        public IRepository<SearchHistory> Histories
        {
            get
            {
                _histories = _histories ?? new MockRepository<SearchHistory>();
                return _histories;
            }
        }

        public IRepository<WeatherUnit> WeatherUnits
        {
            get
            {
                _weatherUnits = _weatherUnits ?? new MockRepository<WeatherUnit>();
                return _weatherUnits;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }

        public int Save()
        {
            return 0;
        }
        public async Task<int> SaveAsync()
        {
            return 0;
        }
    }
}
