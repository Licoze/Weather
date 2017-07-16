using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject;
using NUnit.Framework;
using Weather.BLL.Infrastructure;
using Weather.BLL.Services;
using Weather.Tests.Config;

namespace Weather.Tests.BLL.Tests
{
    class WeatherServiceTests
    {
        private IMapper _mapper;
        private IWeatherService _service;
        [OneTimeSetUp]
        public void Setup()
        {
            var kernel = new StandardKernel(new NinjectTestModule());
            _mapper = kernel.Get<IMapper>();
            _service=new WeatherService(_mapper);

        }
        [Test]
        public void GetWeatherDailyTests()
        {
            var result = _service.GetWeatherDaily("Dnipro", 1);
            Assert.NotNull(result);
        }
    }
}
