using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Ninject;
using NUnit.Framework;
using Weather.BLL.Infrastructure;
using Weather.Controllers;
using Weather.Models;
using Weather.Tests.Config;

namespace Weather.Tests.PL.Tests.Controllers
{
    [TestFixture]
    class HomeControllerTests
    {
        private IMapper _mapper;
        private IServiceFactory _factory;
        [OneTimeSetUp]
        public void Setup()
        {

            var kernel =new StandardKernel(new NinjectTestModule());
            _mapper = kernel.Get<IMapper>();
            _factory = kernel.Get<IServiceFactory>();
        }
        [Test]
        public void IndexNoParamsTest()
        {
            var controller=new HomeController(_factory,_mapper);
            var result = controller.Index().Result as ViewResult;
            Assert.NotNull(result.Model);
        }
        [Test]
        public void SearchHistoryTest()
        {
            var controller = new HomeController(_factory, _mapper);
            var result = controller.SearchHistory().Result as ViewResult;
            Assert.NotNull(result.Model);
        }
        [Test]
        public void IndexWithParamTest()
        {
            var controller = new HomeController(_factory, _mapper);
            var cookie = new HttpCookie("Id")
            {
                Value = 0.ToString()
            };
            controller.HttpContext.Request.Cookies.Add(cookie);
            var form=new SearchFormViewModel()
            {
                CityName = "Lviv",
                ResultCount = 3
            };
            
            var result = controller.Index().Result as ViewResult;
            var actualCount = (result.Model as ForecastViewModel).Units.Count;
            Assert.AreEqual(actualCount,3);
        }
    }
}
