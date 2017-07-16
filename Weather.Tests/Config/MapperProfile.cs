using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Weather.BLL.DTO;
using Weather.DAL.Models;
using Weather.Models;

namespace Weather.Tests.Config
{
    class MapperProfile:Profile
    {

            public MapperProfile()
            {
                CreateMap<CityViewModel, CityDTO>().ReverseMap();
                CreateMap<ForecastUnitViewModel, WeatherUnitDTO>().ReverseMap();
                CreateMap<ForecastViewModel, ForecastDTO>().ReverseMap();
                CreateMap<SearchHistoryViewModel, SearchHistoryDTO>().ReverseMap();
                CreateMap<WeatherUnit, WeatherUnitDTO>().ReverseMap();
                CreateMap<Forecast, ForecastDTO>().ReverseMap();
                CreateMap<SearchHistory, SearchHistoryDTO>().ReverseMap();
                CreateMap<City, CityDTO>().ReverseMap();

        }
        
    }
}
