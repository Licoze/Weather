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
using Weather.DAL.Interfaces;
using Weather.DAL.Models;

namespace Weather.BLL.Services
{
    public class HistoryService:IHistoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public HistoryService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<int> SaveToHistory( ForecastDTO forecastDto,int userId= 0)
        {
            var forecast = _mapper.Map<Forecast>(forecastDto);
            var history = _uow.Histories.Get(userId) ?? new SearchHistory();
            history.Results.Add(forecast);
            if (history.Id == 0)
            {
                _uow.Histories.Create(history);
            }
            else
            {
                _uow.Histories.Update(history);
            }
            await _uow.SaveAsync();
            return history.Id;
        }

        public List<SearchHistoryDTO> GetHistory()
        {
            var entities = _uow.Histories.GetAll();
            return _mapper.Map<List<SearchHistoryDTO>>(entities);
        }
    }
}