using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading.Tasks;
using System.Web.Services.Description;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Weather.BLL.DTO;
using Weather.BLL.Infrastructure;
using Weather.BLL.Interfaces;
using Weather.Infrastructure;
using Weather.Models;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {
        private IMapper _mapper;
        public IWeatherService WeatherService { get; }
        public IHistoryService HistoryService { get; }      
        public HomeController(IServiceFactory service, IMapper mapper)
        {

            _mapper = mapper;
            WeatherService = service.CreateWeatherService();
            HistoryService = service.CreateHistoryService();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var model = new ComplexViewModel();
                model.Form = new SearchFormViewModel();
                model.Form.CityName = "Kiev";
                model.Form.ResultCount = 1;
                var forecastDTO = await WeatherService.GetWeatherDaily("Kiev", 1);
                var forecast=_mapper.Map<ForecastViewModel>(forecastDTO);
                model.Result = forecast;
                var cookie = Request?.Cookies["Id"];
                if (cookie != null)
                {
                    await HistoryService.SaveToHistory(forecastDTO, Convert.ToInt32(cookie.Value));
                }
                else
                {
                    var id = await HistoryService.SaveToHistory(forecastDTO);
                    cookie = new HttpCookie("Id");
                    cookie.Value = id.ToString();
                    Response?.SetCookie(cookie);
                }
                
                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }

        public async Task<ActionResult> SearchHistory()
        {
            var Dto = HistoryService.GetHistory();
            var history = _mapper.Map<List<SearchHistoryViewModel>>(Dto);
            return View(history);
        }
        [HttpPost]
        public async Task<ActionResult> Index(SearchFormViewModel model)
        {
            try
            {
                var resultModel = new ComplexViewModel();
                resultModel.Form = model;
                ForecastDTO forecastDTO=null;
                if (ModelState.IsValid)
                {
                    forecastDTO = await WeatherService.GetWeatherDaily(model.CityName, model.ResultCount);
                    
                }
               
                if (forecastDTO != null)
                {
                    var forecast = _mapper.Map<ForecastViewModel>(forecastDTO);
                    resultModel.Result = forecast;
                    var cookie = Request?.Cookies["Id"];
                    if (cookie != null)
                    {
                        await HistoryService.SaveToHistory(forecastDTO, Convert.ToInt32(cookie.Value));
                    }
                    else
                    {
                        var id = await HistoryService.SaveToHistory(forecastDTO);
                        cookie = new HttpCookie("Id");
                        cookie.Value = id.ToString();
                        Response?.SetCookie(cookie);
                    }
                    return View(resultModel);
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
                
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}