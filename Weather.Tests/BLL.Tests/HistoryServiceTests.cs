using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Components.DictionaryAdapter;
using NUnit.Framework;
using Weather.BLL.DTO;
using Weather.BLL.Services;
using Weather.DAL.Interfaces;
using Weather.DAL.Models;
using Weather.Models;
using Weather.Tests.Config;
using Weather.Tests.Mock;

namespace Weather.Tests.BLL.Tests
{
    [TestFixture]
    class HistoryServiceTests
    {
        private HistoryService service;
        private IMapper _mapper;
        private IUnitOfWork _uow;
        private List<City> _cities;
        private List<Forecast> _forecasts;
        private List<SearchHistory> _histories;
        private List<WeatherUnit> _units;
        [OneTimeSetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            _mapper = config.CreateMapper();
            _uow=new MockUoW();
            _uow.Histories.Create(new SearchHistory()
            {
                Id = 31
            });
            service = new HistoryService(_uow, _mapper);
        }

        [Test]
        public void SaveChangesTest()
        {
            var forecastDto = new ForecastDTO();
            forecastDto.Id = 1;
            var result=service.SaveToHistory(forecastDto).Result;
            Assert.AreEqual(0,result);
        }
        [Test]
        public void GetHistoryTest()
        {

            var history = _uow.Histories.GetAll().FirstOrDefault(x => x.Id == 31);
            var expected = _mapper.Map<SearchHistoryDTO>(history);
            var result = service.GetHistory();
            Assert.AreEqual(result.FirstOrDefault().Id,expected.Id);
        }
    }
}
