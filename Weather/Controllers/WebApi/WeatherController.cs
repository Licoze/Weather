using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Weather.BLL.Infrastructure;
using Weather.BLL.Interfaces;
using Weather.Models;

namespace Weather.Controllers.WebApi
{
    public class WeatherController : ApiController
    {
        private IWeatherService _service;
        private IMapper _mapper;
        public WeatherController(IServiceFactory factory, IMapper mapper)
        {
            _service = factory.CreateWeatherService();
            _mapper = mapper;
        }
        // GET: api/Weather
        [Route("api/Weather/{city}")]
        public IHttpActionResult Get(string city)
        {
            var resultDto = _service.GetWeatherDaily(city);
            var result = _mapper.Map<ForecastViewModel>(resultDto);
            if (result != null)
                return Json(result);
            return NotFound();
        }

        // GET: api/Weather/Dnipro/5
        [Route("api/Weather/{city}/{count}")]
        public IHttpActionResult Get(string city,int count)
        {
            var resultDto = _service.GetWeatherDaily(city,count);
            var result = _mapper.Map<ForecastViewModel>(resultDto);
            if (result != null)
                return Json(result);
            return NotFound();
        }


    }
}
