using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Weather.Models
{ 
        public class WeatherSummary
        {
            public string City { get; set; }
            public List<WeatherUnit> Units { get; set; }

        }

        public class WeatherUnit
        {

            public double DayTemp { get; set; }
            public double NightTemp { get; set; }
            public int Humidity { get; set; }
            public string State { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }  
}