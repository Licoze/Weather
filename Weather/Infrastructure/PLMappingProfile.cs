using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Weather.BLL.DTO;
using Weather.Models;

namespace Weather.Infrastructure
{
    public class PLMappingProfile:Profile
    {
        public PLMappingProfile()
        {
            CreateMap<CityViewModel, CityDTO>().ReverseMap();
            CreateMap<ForecastUnitViewModel, WeatherUnitDTO>().ReverseMap();
            CreateMap<ForecastViewModel, ForecastDTO>().ReverseMap();            
            CreateMap<SearchHistoryViewModel, SearchHistoryDTO>().ReverseMap();
        }
    }
}