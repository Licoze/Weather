using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _mapper = mapper;
        }


        public async Task<int> SaveToHistory( ForecastDTO forecastDto,int userId= 0)
        {
            var forecast = _mapper.Map<Forecast>(forecastDto);
            var history = _db.SearchHistories.Find(userId) ?? new SearchHistory();
            history.Results.Add(forecast);
            if (history.Id == 0)
            {
                _db.SearchHistories.Add(history);
            }
            else
            {
                _db.SearchHistories.Attach(history);
            }
            await _db.SaveChangesAsync();
            return history.Id;
        }

        public async Task<List<SearchHistoryDTO>> GetHistory()
        {
            var entities = _db.SearchHistories.ToList();
            return _mapper.Map<List<SearchHistoryDTO>>(entities);
        }
    }
}