using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.DAL.Models
{
    public class WeatherSummary
    {
        public int Id { get; set; }
        public City City { get; set; }
        public virtual IList<WeatherUnit> Units { get; set; }

        public WeatherSummary()
        {
            Units=new List<WeatherUnit>();
        }

    }
}