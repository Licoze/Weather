using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Services;
using System.Threading.Tasks;
using Weather.Infrastructure;
using Weather.Models;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {
        public IWeatherService Service { get; }

        public HomeController(IWeatherService service)
        {
            Service = service;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var model = new ComplexViewModel();
                model.Form = new SearchFormViewModel();
                model.Form.CityName = "Kiev";
                model.Form.ResultCount = 1;
                model.Result = await Service.GetWeatherDaily("Kiev", 1);
                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Index(SearchFormViewModel model)
        {
            try
            {
                var resultModel = new ComplexViewModel();
                resultModel.Form = model;
                if (ModelState.IsValid)
                {
                    resultModel.Result = await Service.GetWeatherDaily(model.CityName, model.ResultCount);

                }
                resultModel.Result = resultModel.Result ?? await Service.GetWeatherDaily("Kiev", 1);
                return View(resultModel);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}