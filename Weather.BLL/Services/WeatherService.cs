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
        public WeatherService(IMapper mapper)
        {
            _url = "http://api.openweathermap.org/";
            _apiKey = ConfigurationManager.AppSettings["apiKey"];
            _mapper = mapper;
        }

        public async Task<ForecastDTO> GetWeatherDaily(string cityname, int count=1)
        {
            try
            {
                string requestStr = String.Format("data/2.5/forecast/daily?q={0}&cnt={1}&units=metric", cityname,
                    count);
                string response = await Request(requestStr);
                if (response == string.Empty)
                    return null;
                var obj = JObject.Parse(response);
                var weather = new Forecast();
                string cityName = (string) obj["city"]["name"];
                var city = new City()
                {
                    Name = cityName
                };
                weather.City = city;
                var q = from i in obj["list"]
                    select new WeatherUnit()
                    {
                        DayTemp = (double) i["temp"]["day"],
                        NightTemp = (double) i["temp"]["night"],
                        Humidity = (int) i["humidity"],
                        State = (string) i["weather"][0]["main"],
                        Description = (string) i["weather"][0]["description"],
                        Icon = (string) i["weather"][0]["icon"],
                        Time = DateTimeOffset.FromUnixTimeSeconds((long) i["dt"]).UtcDateTime
                    };
                weather.Units = q.ToList();
                return _mapper.Map<ForecastDTO>(weather);
            }
            catch (Exception ex)
            {
                return null;
            }
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