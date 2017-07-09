﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Infrastructure
{
    public interface IWeatherService
    {
        Task<WeatherSummary> GetWeatherDaily(string city, int count = 1);
    }
}
