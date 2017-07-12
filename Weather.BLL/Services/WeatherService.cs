using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using AutoMapper;
using Weather.DAL.Models;
using Newtonsoft.Json.Linq;
using Weather.BLL.DTO;
using Weather.BLL.Infrastructure;
using Weather.DAL.Infrastructure;

namespace Weather.BLL.Services
{
    public class WeatherService: IWeatherService
    {
        private readonly string _url;
        private readonly string _apiKey;
        private readonly IMapper _mapper;
        private readonly WeatherDb _db;
        public WeatherService(WeatherDb db, IMapper mapper)
        {
            _url = "http://api.openweathermap.org/";
            _apiKey = ConfigurationManager.AppSettings["apiKey"];
            _db = db;
            _mapper = mapper;
        }

        public async Task<WeatherSummaryDTO> GetWeatherDaily(string cityname, int count=1)
        {
            string requestStr=String.Format("data/2.5/forecast/daily?q={0}&cnt={1}&units=metric",cityname,count);
            string response = await Request(requestStr);
            if (response == string.Empty)
                return null;
            var obj= JObject.Parse(response);
            var weather = new WeatherSummary();           
            string cityName = (string)obj["city"]["name"];
            var city = _db.Cities.First(c => c.Name == cityName) 
                        ?? new City()
                       {
                           Name=cityName
                       };
            weather.City = city;
            var q = from i in obj["list"]
                select new WeatherUnit()
                {
                    DayTemp = (double)i["temp"]["day"],
                    NightTemp = (double)i["temp"]["night"],
                    Humidity = (int)i["humidity"],
                    State = (string)i["weather"][0]["main"],
                    Description = (string)i["weather"][0]["description"],
                    Icon = (string)i["weather"][0]["icon"],
                    Time= DateTimeOffset.FromUnixTimeSeconds((long)i["dt"]).UtcDateTime
                };
            weather.Units = q.ToList();
            _db.Summaries.Add(weather);
            await _db.SaveChangesAsync();
            return _mapper.Map<WeatherSummaryDTO>(weather);
        }

        private async Task<string> Request(string requestStr)
        {
            
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(requestStr + "&APPID=" + _apiKey);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();

                    }
                    return string.Empty;
                }
        }

    }
}