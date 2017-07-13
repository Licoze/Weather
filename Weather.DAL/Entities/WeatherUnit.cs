﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.DAL.Models
{
    public class WeatherUnit
    {
        public int Id { get; set; }
        public double DayTemp { get; set; }
        public double NightTemp { get; set; }
        public int Humidity { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime Time { get; set; }
        public virtual Forecast WeatherSummary { get; set; }
    }
}