using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using System.Linq.Expressions;
using Weather.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Weather.Infrastructure;

namespace Weather.Services
{
    public class WeatherService: IWeatherService
    {
        private readonly string _url;
        private readonly string _apiKey;
        public WeatherService()
        {
            _url = "http://api.openweathermap.org/";
            _apiKey = ConfigurationManager.AppSettings["apiKey"];

        }

        public async Task<WeatherSummary> GetWeatherDaily(string city, int count=1)
        {
            string requestStr=String.Format("data/2.5/forecast/daily?q={0}&cnt={1}&units=metric",city,count);
            string response = await Request(requestStr);
            if (response == string.Empty)
                return null;
            var obj= JObject.Parse(response);
            var weather = new WeatherSummary();
            
            weather.City = (string)obj["city"]["name"];
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
            return weather;
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