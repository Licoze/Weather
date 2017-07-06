using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Services;
using System.Threading.Tasks;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {
        public WeatherService Service { get; }

        public HomeController()
        {
            Service = new WeatherService();
        }

        public async Task<ActionResult> Index()
        {
            var model = await new WeatherService().GetWeatherDaily("Kiev", 1);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Index(string city, int days)
        {
            var model = await new WeatherService().GetWeatherDaily(city, days);
            return View(model);

        }
    }
}