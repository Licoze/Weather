using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Weather.BLL.DTO;
using Weather.BLL.Interfaces;
using Weather.DAL.Infrastructure;
using Weather.DAL.Models;

namespace Weather.BLL.Services
{
    public class HistoryService:IHistoryService
    {
        private readonly WeatherDb _db;
        private readonly IMapper _mapper;
        public HistoryService(WeatherDb db, IMapper mapper)
        {
            _db = db;
        }

        public async Task AddCityToPreset(int userId, CityDTO city)
        {
            var cityEnity = _mapper.Map<City>(city);
            _db.Cities.Add(cityEnity);
            _db.SearchHistories.Find(userId).CitiesPreset.Add(cityEnity);
            await _db.SaveChangesAsync();

        }

        public List<CityDTO> GetCityPreset(int userId)
        {
            var history = _db.SearchHistories.Find(userId);
            if (history != null)
            {
                return _mapper.Map<List<CityDTO>>(history.CitiesPreset);
            }
            else
            {
          
            }
        }
        public async Task SaveToHistory(int userId, WeatherSummaryDTO summary)
        {
            var summaryEntity = _mapper.Map<WeatherSummary>(summary);
            var history = _db.SearchHistories.Find(userId)??new SearchHistory();
            var city = _mapper.Map<CityDTO>(summary.City);
            await AddCityToPreset(userId, city);
            history.Results.Add(summaryEntity);
            _db.SearchHistories.Add(history);
            await _db.SaveChangesAsync();

        }
    }
}