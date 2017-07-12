using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Weather.BLL.DTO;
using Weather.DAL.Models;

namespace Weather.BLL.Infrastructure
{
    public class BLLMappingProfile:Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<WeatherUnit, WeatherUnitDTO>().ReverseMap();
            CreateMap<WeatherSummary, WeatherSummaryDTO>().ReverseMap();
            CreateMap<SearchHistory, SearchHistoryDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}
