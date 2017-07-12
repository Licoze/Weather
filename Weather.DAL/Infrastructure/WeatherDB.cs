using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Weather.DAL.Models;

namespace Weather.DAL.Infrastructure
{
    public class WeatherDb:DbContext
    {
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<WeatherSummary> Summaries { get; set; }
        public DbSet<WeatherUnit> WeatherUnits { get; set; }
        public DbSet<City> Cities { get; set; }
        public WeatherDb(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    }
}