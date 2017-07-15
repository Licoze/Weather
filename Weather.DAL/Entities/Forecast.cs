using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.DAL.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public virtual City City { get; set; }
        public virtual IList<WeatherUnit> Units { get; set; }

        public Forecast()
        {
            Units = new List<WeatherUnit>();

        }

    }
}