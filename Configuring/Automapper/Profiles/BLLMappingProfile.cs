using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Weather.BLL.DTO;
using Weather.DAL.Models;

namespace Configuring.Automapper.Profiles
{
    public class BLLMappingProfile:Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<WeatherUnit, WeatherUnitDTO>().ReverseMap();
            CreateMap<Forecast, ForecastDTO>().ReverseMap();
            CreateMap<SearchHistory, SearchHistoryDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}
