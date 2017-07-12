using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Weather.DAL.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public IList<WeatherSummary> Results { get; set; }
        public IList<City> CitiesPreset { get; set; }
        public SearchHistory()
        {
            Results=new List<WeatherSummary>();
            CitiesPreset=new List<City>();
        }
    }
}