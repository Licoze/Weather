using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.DAL.Infrastructure;
using Weather.DAL.Interfaces;
using Weather.DAL.Models;
using Weather.DAL.Repositories;

namespace Weather.DAL.Infrastructure
{
    public class WeatherUoW : IUnitOfWork
    {
        private WeatherDb _db;
        private Repository<City> _cities;
        private Repository<Forecast> _forecasts;
        private Repository<SearchHistory> _histories;
        private Repository<WeatherUnit> _weatherUnits;
        private bool _disposed;
        public WeatherUoW(WeatherDb db)
        {
            _db = db;
        }
        public IRepository<City> Cities => _cities ?? new Repository<City>(_db);

        public IRepository<Forecast> Forecasts => _forecasts ?? new Repository<Forecast>(_db);

        public IRepository<SearchHistory> Histories => _histories ?? new Repository<SearchHistory>(_db);

        public IRepository<WeatherUnit> WeatherUnits => _weatherUnits ?? new Repository<WeatherUnit>(_db);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _db.Dispose();
            }

            
            _disposed = true;
        }

        public int Save()
        {
           return _db.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
           return await _db.SaveChangesAsync();
        }
    }
}
